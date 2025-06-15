using HospitalManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Infrastructure.Seeders
{
    public static class DefaultAdminSeeder
    {
        public static async Task SeedAdminUserAsync(
            UserManager<MyApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@hospital.com";
            string adminPassword = "Admin123!";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var user = new MyApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync("Admin"))
                    {
                        await roleManager.CreateAsync(new IdentityRole("Admin"));
                    }

                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
