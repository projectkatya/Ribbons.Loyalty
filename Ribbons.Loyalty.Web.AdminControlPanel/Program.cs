using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Ribbons.Loyalty.Web.Setup;
using System.Threading.Tasks;

namespace Ribbons.Loyalty.Web.AdminControlPanel
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.SetupControlPanel();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}/{id?}");

            await app.InitializeAsync();

            await app.RunAsync();
        }
    }
}