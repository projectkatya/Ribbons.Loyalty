using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Loyalty.Services.UserManagement;
using Ribbons.Users.Management;
using System.Threading.Tasks;

namespace Ribbons.Loyalty.Services.Setup
{
    public static class SetupExtensions
    {
        public static async Task SetupAdminControlPanelAsync(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.Configure<AdminDbConfig>(builder.Configuration.GetSection(nameof(AdminDb)));
            builder.Services.AddSingleton<IDatabaseManager<AdminDb>>();
            builder.Services.AddKeyedScoped<IUserManager, AdminManager>(LoyaltyUserTypeId.Admin);
            builder.Services.AddKeyedScoped<IUserManager, PartnerAdminManager>(LoyaltyUserTypeId.PartnerAdmin);
        }

        public static async Task SetupPartnerControlPanelAsync(this WebApplicationBuilder builder)
        {

        }
    }
}