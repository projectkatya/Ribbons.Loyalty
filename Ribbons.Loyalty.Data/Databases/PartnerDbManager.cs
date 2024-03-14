using Microsoft.Extensions.Logging;
using Ribbons.Data;
using System;
using System.Threading.Tasks;

namespace Ribbons.Loyalty.Data.Databases
{
    public sealed class PartnerDbManager : DatabaseManager<PartnerDb>
    {
        private IDatabaseManager<AdminDb> AdminDbManager { get; }

        public PartnerDbManager(ILogger<PartnerDbManager> logger, IDatabaseManager<AdminDb> adminDbManager) : base(logger)
        {
            AdminDbManager = adminDbManager;
        }

        protected override DatabaseConfig GetConfiguration(string identifier)
        {
            throw new NotImplementedException();
        }

        protected override Task<DatabaseConfig> GetConfigurationAsync(string identifier)
        {
            throw new NotImplementedException();
        }

        protected override PartnerDb CreateInstance(DatabaseConfig configuration)
        {
            throw new NotImplementedException();
        }
    }
}