using BookstoreApp.Infrastructure.Data.Models;
using BookstoreApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace BookstoreApp.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (dbContext.Users.FirstOrDefault(u => u.Email == "mmaarriioo2007@gmail.com") == null
                && dbContext.Users.FirstOrDefault(u => u.Email == "admin@admin.com") == null)
            {
                await SeedUsersAsync(userManager);
            }

            if (userManager != null && roleManager != null)
            {
                var adminRole = new IdentityRole("Admin");
                var userRole = new IdentityRole("User");

                await roleManager.CreateAsync(adminRole);
                await roleManager.CreateAsync(userRole);

                var user = await userManager.FindByEmailAsync("mmaarriioo2007@gmail.com");

                if (user != null)
                {
                    await userManager.AddToRoleAsync(user, userRole.Name);
                }

                var admin = await userManager.FindByEmailAsync("admin@admin.com");

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, adminRole.Name);
                }
            }
        }
        private async static Task SeedUsersAsync(UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser()
            {
                Id = "00359143-b644-4d40-ad75-b35df9341f0b",
                Email = "mmaarriioo2007@gmail.com",
                UserName = "mmaarriioo2007",
            };

            var admin = new IdentityUser()
            {
                Id = "9a2f0ce7-97a9-4806-a706-5e239efd4dd2",
                Email = "admin@admin.com",
                UserName = "admin@admin.com",
            };

            await userManager.CreateAsync(user, "123654Mario_");
            await userManager.CreateAsync(admin, "Admin15_");
        }
    }
}
