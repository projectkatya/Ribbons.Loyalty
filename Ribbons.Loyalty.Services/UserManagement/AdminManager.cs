using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Users.Management;

namespace Ribbons.Loyalty.Services.UserManagement
{
    public sealed class AdminManager : UserManager<AdminDb>
    {
        public AdminManager(ILogger<AdminManager> logger, IDatabaseManager<AdminDb> databaseManager) : base(LoyaltyUserTypeId.Admin, logger, databaseManager)
        {
        }
    }
}