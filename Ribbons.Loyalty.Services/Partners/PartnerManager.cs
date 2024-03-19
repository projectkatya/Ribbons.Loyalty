using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Loyalty.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Extensions;
using Ribbons.Loyalty.Services.Partners.Models;
using Ribbons.Loyalty.Services.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ribbons.Loyalty.Services.Partners
{
    public sealed class PartnerManager : IPartnerManager
    {
        private ILogger Logger { get; }
        private IDatabaseManager<AdminDb> AdminDbManager { get; }
        private IDatabaseManager<PartnerDb> PartnerDbManager { get; }
        private IUserManager UserManager { get; }
        private string AccountNumberCharacterSet { get; }

        public PartnerManager(
            ILogger<PartnerManager> logger, 
            IDatabaseManager<AdminDb> adminDbManager, 
            IDatabaseManager<PartnerDb> partnerDbManager, 
            IUserManager userManager)
        {
            Logger = logger;
            AdminDbManager = adminDbManager;
            PartnerDbManager = partnerDbManager;
            UserManager = userManager;
            AccountNumberCharacterSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        }

        public async Task<CreatePartnerResponse> CreatePartnerAsync(CreatePartnerRequest createPartnerRequest)
        {
            try
            {
                if (!createPartnerRequest.TryValidateObject(out Dictionary<string, string> validationErrors))
                {
                    return CreatePartnerResponse.PartnerInvalid(validationErrors);
                }

                Database adminDb = await AdminDbManager.GetDatabaseAsync();

                if (await adminDb.HasPartnersWithAlias(createPartnerRequest.Alias))
                {
                    return CreatePartnerResponse.AliasTaken();
                }

                DbServer dbServer = await adminDb.FindAsync<DbServer>(createPartnerRequest.DbServerId);

                if (dbServer == null)
                {
                    return CreatePartnerResponse.DbServerNotFound();
                }

                DateTime now = DateTime.Now;

                Partner partner = new()
                {
                    CreatedDate = now,
                    ModifiedDate = now,
                    AccountNumber = AccountNumberCharacterSet.GetRandomString(12),
                    Alias = createPartnerRequest.Alias,
                    Name = createPartnerRequest.Name,
                    Status = PartnerStatus.PendingDeployment,
                    BusinessName = createPartnerRequest.BusinessName,
                    BillingAddress = createPartnerRequest.BillingAddress,
                    Country = createPartnerRequest.Country,
                    State = createPartnerRequest.State,
                    City = createPartnerRequest.City,
                    ZipCode = createPartnerRequest.ZipCode
                };

                await adminDb.AddAsync(partner);

                await adminDb.SaveChangesAsync();

                string databaseName = $"loyalty_partner_{partner.PartnerId.ToString().PadLeft(21, '0')}";

                PartnerDbConfig partnerDbConfig = new()
                {
                    PartnerId = partner.PartnerId,
                    Provider = dbServer.Provider,
                    ConnectionString = dbServer.SetDatabase(databaseName)
                };

                await adminDb.AddAsync(partnerDbConfig);

                await adminDb.SaveChangesAsync();

                _ = Task.Run(async () => await DeployPartnerAsync(partner.PartnerId));

                return CreatePartnerResponse.Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError("{methodName} failed with exception {ex}", nameof(CreatePartnerAsync), ex);

                return CreatePartnerResponse.Error();
            }
        }

        public async Task DeployPartnerAsync(long partnerId)
        {
            try
            {
                Database adminDb = await AdminDbManager.GetDatabaseAsync();

                Partner partner = await adminDb.FindAsync<Partner>(partnerId);

                if (partner == null)
                {
                    return;
                }

                partner.Status = PartnerStatus.Deploying;

                await adminDb.SaveChangesAsync();

                PartnerDeployment partnerDeployment = new()
                {
                    PartnerId = partnerId,
                    Status = PartnerDeploymentStatus.New,
                    StartDate = DateTime.Now
                };

                await adminDb.AddAsync(partnerDeployment);

                await adminDb.SaveChangesAsync();

                partnerDeployment.Status = PartnerDeploymentStatus.InProgress;
                
                partnerDeployment.DbMigrationStartDate = DateTime.Now;

                await adminDb.SaveChangesAsync();

                MigrationStatus migrationStatus = await PartnerDbManager.MigrateAsync(partner.Alias);

                partnerDeployment.DbMigrationFinishDate = DateTime.Now;
                
                partnerDeployment.DbMigrationStatus = migrationStatus;

                partnerDeployment.FinishDate = DateTime.Now;

                await adminDb.SaveChangesAsync();

                if (migrationStatus == MigrationStatus.Complete)
                {
                    Database partnerDb = await PartnerDbManager.GetDatabaseAsync(partner.Alias);

                    partner.Status = PartnerStatus.Active;

                    partnerDeployment.Status = PartnerDeploymentStatus.Complete;

                    await partnerDb.AddAsync(partner);

                    await partnerDb.SaveChangesAsync();

                    await adminDb.SaveChangesAsync();

                    return;
                }

                partnerDeployment.Status = PartnerDeploymentStatus.Incomplete;

                await adminDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError("{methodName} failed with exception {ex}", nameof(DeployPartnerAsync), ex);
            }
        }
    }
}