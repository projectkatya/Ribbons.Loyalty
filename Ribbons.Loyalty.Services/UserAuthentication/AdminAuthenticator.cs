using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Users.Authentication;

namespace Ribbons.Loyalty.Services.UserAuthentication
{
    public sealed class AdminAuthenticator : UserAuthenticator<AdminDb>
    {
        public AdminAuthenticator(ILogger<AdminAuthenticator> logger, IDatabaseManager<AdminDb> databaseManager) : 
            base(LoyaltyUserTypeId.Admin, logger, databaseManager)
        {
        }
    }
}