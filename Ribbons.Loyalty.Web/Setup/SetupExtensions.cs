using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Ribbons.Data;
using Ribbons.Loyalty.Data.Databases;
using Ribbons.Loyalty.Data.Definitions;
using Ribbons.Loyalty.Services.Partners;
using Ribbons.Loyalty.Services.Users;
using Ribbons.Users.Management.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ribbons.Loyalty.Web.Setup
{
    public static class SetupExtensions
    {
        public static void SetupControlPanel(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

            builder.Services.AddMemoryCache();

            builder.Services.Configure<AdminDbConfig>(builder.Configuration.GetSection(nameof(AdminDb)));
            builder.Services.AddSingleton<IDatabaseManager<AdminDb>, AdminDbManager>();
            builder.Services.AddSingleton<IDatabaseManager<PartnerDb>, PartnerDbManager>();
            builder.Services.AddSingleton<IUserManager, UserManager>();
            builder.Services.AddSingleton<IUserAuthenticator, UserAuthenticator>();
            builder.Services.AddSingleton<IPartnerManager, PartnerManager>();
        }

        public static async Task InitializeAsync(this WebApplication app)
        {
            IServiceProvider serviceProvider = app.Services;

            IDatabaseManager<AdminDb> adminDbManager = serviceProvider.GetRequiredService<IDatabaseManager<AdminDb>>();
            IUserManager userManager = serviceProvider.GetRequiredService<IUserManager>();
            IPartnerManager partnerManager = serviceProvider.GetRequiredService<IPartnerManager>();

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