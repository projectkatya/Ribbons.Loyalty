using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using Ribbons.Data;
using Ribbons.Loyalty.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Extensions;
using Ribbons.Loyalty.Services.Partners.Models;
using Ribbons.Loyalty.Services.Users;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Cryptography;
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
                    return CreatePartnerResponse.InvalidRequest(validationErrors);
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

                await PartnerDbManager.MigrateAsync(partner.Alias);

                return CreatePartnerResponse.Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError("{methodName} failed with exception {ex}", nameof(CreatePartnerAsync), ex);

                return CreatePartnerResponse.Error();
            }
        }
    }
}