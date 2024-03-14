using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Users.Management;

namespace Ribbons.Loyalty.Services.UserManagement
{
    public sealed class PartnerAdminManager : UserManager<PartnerDb>
    {
        public PartnerAdminManager(ILogger<PartnerAdminManager> logger, IDatabaseManager<PartnerDb> databaseManager) : base(LoyaltyUserTypeId.PartnerAdmin, logger, databaseManager)
        {
        }
    }
}