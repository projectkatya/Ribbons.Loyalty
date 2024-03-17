using Microsoft.EntityFrameworkCore;
using Ribbons.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ribbons.Loyalty.Data.Databases
{
    public static class DatabaseExtensions
    {
        public static IQueryable<PartnerDbConfig> GetPartnerDbConfig(this Database database, string identifier)
        {
            _ = long.TryParse(identifier, out long partnerId);
            
            return from p in database.Set<Partner>()
                   join pdb in database.Set<PartnerDbConfig>() on p.PartnerId equals pdb.PartnerId
                   where p.PartnerId == partnerId || p.AccountNumber == identifier || p.Alias == identifier
                   select pdb;
        }

        public static async Task<bool> HasPartnersWithAlias(this Database database, string alias)
        {
            return await database
                .Set<Partner>()
                .AsNoTracking()
                .AnyAsync(x => x.Alias == alias);
        }

        public static async Task<bool> HasAnyPartnersWithAccountNumber(this Database database, string accountNumber)
        {
            return await database
                .Set<Partner>()
                .AsNoTracking()
                .AnyAsync(x => x.AccountNumber == accountNumber);
        }
    }
}