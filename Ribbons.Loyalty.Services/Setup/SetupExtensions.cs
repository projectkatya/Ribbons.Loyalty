using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Loyalty.Services.Users;
using Ribbons.Users.Management;
using Ribbons.Users.Management.Models;
using System;
using System.Threading.Tasks;

namespace Ribbons.Loyalty.Services.Setup
{
    public static class SetupExtensions
    {
        public static void  SetupAdminControlPanelAsync(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.Configure<AdminDbConfig>(builder.Configuration.GetSection(nameof(AdminDb)));
            builder.Services.AddSingleton<IDatabaseManager<AdminDb>, AdminDbManager>();
            builder.Services.AddSingleton<IDatabaseManager<PartnerDb>, PartnerDbManager>();
            builder.Services.AddSingleton<IUserManager<LoyaltyUser>, UserManager>();
        }

        public static async Task InitializeAsync(this WebApplication app)
        {
            IServiceProvider serviceProvider = app.Services;

            IDatabaseManager<AdminDb> adminDbManager = serviceProvider.GetRequiredService<IDatabaseManager<AdminDb>>();
            IUserManager<LoyaltyUser> userManager = serviceProvider.GetRequiredService<IUserManager<LoyaltyUser>>();

            await adminDbManager.MigrateAsync();

            await userManager.CreateUserAsync(LoyaltyUser.Admin, new CreateUserRequest
            {
                UserName = "admin",
                EmailAddress = "admin@email.com",
                FirstName = "Loyalty",
                LastName = "Administrator",
                Password = "admin"
            });
        }
    }
}