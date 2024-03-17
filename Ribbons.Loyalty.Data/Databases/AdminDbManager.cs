using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ribbons.Data;
using System.Threading.Tasks;

namespace Ribbons.Loyalty.Data.Databases
{
    public class AdminDbManager : DatabaseManager<AdminDb>
    {
        private AdminDbConfig Configuration { get; }

        public AdminDbManager(ILogger<AdminDbManager> logger, IOptions<AdminDbConfig> options) : base(logger)
        {
            Configuration = options.Value;
        }

        protected override DatabaseConfig GetConfiguration(string identifier)
        {
            return Configuration;
        }

        protected override async Task<DatabaseConfig> GetConfigurationAsync(string identifier)
        {
            return await Task.FromResult(Configuration);
        }

        protected override Database CreateInstance(DatabaseConfig configuration)
        {
            AdminDb instance = configuration.Provider switch
            {
                DatabaseProvider.MsSql => new AdminDbMsSql(),
                DatabaseProvider.MySql => new AdminDbMySql(),
                DatabaseProvider.Npgsql => new AdminDbNpgsql(),
                DatabaseProvider.Oracle => new AdminDbOracle(),
                DatabaseProvider.Sqlite => new AdminDbSqlite(),
                _ => null
            };

            instance?.SetConnectionString(configuration.ConnectionString);

            return instance;
        }
    }
}