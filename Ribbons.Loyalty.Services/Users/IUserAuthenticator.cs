using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Users.Authentication;

namespace Ribbons.Loyalty.Services.Users
{
    public interface IUserAuthenticator : IUserAuthenticator<LoyaltyUser>
    {
    }
}