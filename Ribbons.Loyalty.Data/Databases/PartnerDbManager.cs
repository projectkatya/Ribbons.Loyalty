using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Ribbons.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ribbons.Loyalty.Data.Databases
{
    public sealed class PartnerDbManager : DatabaseManager<PartnerDb>
    {
        private IDatabaseManager<AdminDb> AdminDbManager { get; }
        private IMemoryCache MemoryCache { get; }
        private TimeSpan SuccessCacheDuration { get; }
        private TimeSpan FailedCacheDuration { get; set; }

        public PartnerDbManager(ILogger<PartnerDbManager> logger, IDatabaseManager<AdminDb> adminDbManager, IMemoryCache memoryCache) : base(logger)
        {
            AdminDbManager = adminDbManager;
            MemoryCache = memoryCache;
            SuccessCacheDuration = TimeSpan.FromMinutes(30);
            FailedCacheDuration = TimeSpan.FromSeconds(1);
        }

        protected override DatabaseConfig GetConfiguration(string identifier)
        {
            return MemoryCache.GetOrCreate($"partnerdb_{identifier}", (entry) =>
            {
                try
                {
                    Database adminDb = AdminDbManager.GetDatabase(identifier);

                    LogStart(identifier);

                    PartnerDbConfig partnerDbConfig = adminDb.GetPartnerDbConfig(identifier).FirstOrDefault();

                    if (partnerDbConfig == null)
                    {
                        LogNullRetrieval(identifier);

                        entry.SetAbsoluteExpiration(FailedCacheDuration);

                        return null;
                    }

                    LogSuccessfulRetrieval(identifier);

                    entry.SetAbsoluteExpiration(SuccessCacheDuration);

                    return new DatabaseConfig
                    {
                        Provider = partnerDbConfig.Provider,
                        ConnectionString = partnerDbConfig.ConnectionString
                    };
                }
                catch (Exception ex)
                {
                    LogFailedRetrieval(identifier, ex);

                    entry.SetAbsoluteExpiration(FailedCacheDuration);

                    return null;
                }
            });
        }

        protected override Task<DatabaseConfig> GetConfigurationAsync(string identifier)
        {
            return MemoryCache.GetOrCreateAsync($"partnerdb_{identifier}", async (entry) =>
            {
                try
                {
                    Database adminDb = AdminDbManager.GetDatabase(identifier);

                    LogStart(identifier);

                    PartnerDbConfig partnerDbConfig = await adminDb.GetPartnerDbConfig(identifier).FirstOrDefaultAsync();

                    if (partnerDbConfig == null)
                    {
                        LogNullRetrieval(identifier);

                        entry.SetAbsoluteExpiration(FailedCacheDuration);

                        return null;
                    }

                    LogSuccessfulRetrieval(identifier);

                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                    return new DatabaseConfig
                    {
                        Provider = partnerDbConfig.Provider,
                        ConnectionString = partnerDbConfig.ConnectionString
                    };
                }
                catch (Exception ex)
                {
                    LogFailedRetrieval(identifier, ex);

                    entry.SetAbsoluteExpiration(FailedCacheDuration);

                    return null;
                }
            });
        }

        protected override Database CreateInstance(DatabaseConfig configuration)
        {
            Database instance = configuration?.Provider switch
            {
                DatabaseProvider.MsSql => new PartnerDbMsSql(),
                DatabaseProvider.MySql => new PartnerDbMySql(),
                DatabaseProvider.Npgsql => new PartnerDbNpgsql(),
                DatabaseProvider.Oracle => new PartnerDbOracle(),
                DatabaseProvider.Sqlite => new PartnerDbSqlite(),
                _ => null
            };

            instance?.SetConnectionString(configuration.ConnectionString);

            return instance;
        }

        private void LogStart(string identifier)
        {
            Logger.LogTrace("Retrieving partner database configurations for identifier {identifier}", identifier);
        }

        private void LogNullRetrieval(string identifier)
        {
            Logger.LogTrace("Failed to retrieve partner database configurations for identifier {identifier}", identifier);
        }

        private void LogSuccessfulRetrieval(string identifier)
        {
            Logger.LogTrace("Retrieved partner database configurations for identifier {identifier}", identifier);
        }

        private void LogFailedRetrieval(string identifier, Exception ex)
        {
            Logger.LogError("Failed to get partner database configuration for identifier {identifier} with exception {ex}", identifier, ex);
        }
    }
}