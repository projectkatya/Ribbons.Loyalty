using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Users.Management;

namespace Ribbons.Loyalty.Services.Users
{
    public sealed class UserManager : UserManager<LoyaltyUser>, IUserManager
    {
        public UserManager(ILogger<UserManager> logger, IDatabaseManager<AdminDb> adminDbManager, IDatabaseManager<PartnerDb> partnerDbManager) : base(logger)
        {
            UserSources.Add(LoyaltyUser.Admin, adminDbManager);
            UserSources.Add(LoyaltyUser.PartnerAdmin, partnerDbManager);
            UserSources.Add(LoyaltyUser.Member, partnerDbManager);
        }
    }
}