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
            SeedGuestRole(services);
            SeedVillas(services);
            SeedMainCategories(services);
            SeedSubCategories(services);
            SeedServices(services);

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
            var context = services.GetRequiredService<GRHelperDbContext>();
            Task.Run(async () =>
            {
                var role = new IdentityRole { Name = AdministratorRoleName };

                if (!await roleManager.RoleExistsAsync(AdministratorRoleName))
                {
                    await roleManager.CreateAsync(role);
                }

                const string adminEmail = "master@gr.com";
                const string adminPass = "admin123";

                if (!context.Users.Any(u=>u.Email==adminEmail))
                {
                    var admin = new IdentityUser
                    {
                        Email = adminEmail,
                        UserName = adminEmail
                    };
                    await userManager.CreateAsync(admin, adminPass);
                    await userManager.AddToRoleAsync(admin, role.Name);
                }
            })
                .GetAwaiter()
                .GetResult();
        }
        private static void SeedGuestRole(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            Task.Run(async () =>
            {
                var role = new IdentityRole { Name = GuestRoleName };

                if (!await roleManager.RoleExistsAsync(GuestRoleName))
                {
                    await roleManager.CreateAsync(role);
                }
            })
                .GetAwaiter()
                .GetResult();
        }
            
        private static void SeedVillas(IServiceProvider services)
        {
                var context = services.GetRequiredService<GRHelperDbContext>();
                Task.Run(async () => { await DataInitializer.SeedVillas(context); }).GetAwaiter().GetResult();
        }
        private static void SeedMainCategories(IServiceProvider services)
        {
            var context = services.GetRequiredService<GRHelperDbContext>();
            Task.Run(async () => { await DataInitializer.SeedCategories(context); }).GetAwaiter().GetResult();
        }
        private static void SeedSubCategories(IServiceProvider services)
        {
            var context = services.GetRequiredService<GRHelperDbContext>();
            Task.Run(async () => { await DataInitializer.SeedSubCategories(context); }).GetAwaiter().GetResult();
        }
        private static void SeedServices(IServiceProvider services)
        {
            var context = services.GetRequiredService<GRHelperDbContext>();
            Task.Run(async () => { await DataInitializer.SeedServices(context); }).GetAwaiter().GetResult();
        }
    }
}
