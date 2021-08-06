using GuestRelationsHelper.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

using static GuestRelationsHelper.WebConstants;

namespace GuestRelationsHelper.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;
            MigrateDatabase(services);
            SeedAdministrator(services);
            SeedVillas(services);
            return app;
        }


        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<GRHelperDbContext>();
            data.Database.Migrate();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            Task.Run(async () =>
            {
                if (!await roleManager.RoleExistsAsync(AdministratorRoleName))
                {
                    return;
                }
                var role = new IdentityRole { Name = AdministratorRoleName };
                await roleManager.CreateAsync(role);

                const string adminEmail = "master@gr.com";
                const string adminPass = "admin123";

                var admin = new IdentityUser
                {
                    Email = adminEmail,
                    UserName = adminEmail
                };

                await userManager.CreateAsync(admin, adminPass);
                await userManager.AddToRoleAsync(admin, AdministratorRoleName);
            })
                .GetAwaiter()
                .GetResult();
        }
        private static void SeedVillas(IServiceProvider services)
        {
            var context = services.GetRequiredService<GRHelperDbContext>();
            if (!context.Villas.Any())
            {

            }
        }

    }
}
