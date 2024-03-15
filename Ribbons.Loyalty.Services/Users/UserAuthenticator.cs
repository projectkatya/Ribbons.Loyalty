using Microsoft.Extensions.Logging;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Users.Authentication;
using Ribbons.Users.Authentication.Models;

namespace Ribbons.Loyalty.Services.Users
{
    public sealed class UserAuthenticator : UserAuthenticator<LoyaltyUser>
    {
        public UserAuthenticator(ILogger<UserAuthenticator> logger, IDatabaseManager<AdminDb> adminDbManager, IDatabaseManager<PartnerDb> partnerDbManager) : base(logger)
        {
            UserSources.Add(LoyaltyUser.Admin, adminDbManager);
            
            UserSources.Add(LoyaltyUser.PartnerAdmin, partnerDbManager);
            
            UserSources.Add(LoyaltyUser.Member, partnerDbManager);
            
            UserCookieSettings.Add(LoyaltyUser.Admin, new CookieSettings
            {
                DomainCookieName = "rl_a_domain",
                SessionIdCookieNameTemplate = "rl_a_sid_{0}",
                SessionSecretCookieNameTemplate = "rl_a_ss_{0}"
            });

            UserCookieSettings.Add(LoyaltyUser.PartnerAdmin, new CookieSettings
            {
                DomainCookieName = "rl_pa_domain",
                SessionIdCookieNameTemplate = "rl_pa_sid_{0}",
                SessionSecretCookieNameTemplate = "rl_pa_ss_{0}"
            });

            UserCookieSettings.Add(LoyaltyUser.Member, new CookieSettings
            {
                DomainCookieName = "rl_m_domain",
                SessionIdCookieNameTemplate = "rl_m_sid_{0}",
                SessionSecretCookieNameTemplate = "rl_m_ss_{0}"
            });
        }
    }
}