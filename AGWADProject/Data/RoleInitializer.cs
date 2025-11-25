namespace AGWADProject.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading.Tasks;

    public static class RoleInitializer
    {
        public static async Task SeedRolesAndUsersAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();


            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }


            var adminEmail = "alexadmin@gmail.com";
            var userEmail = "alex1@gmail.com";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser != null && !(await userManager.IsInRoleAsync(adminUser, "Admin")))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            var normalUser = await userManager.FindByEmailAsync(userEmail);
            if (normalUser != null && !(await userManager.IsInRoleAsync(normalUser, "User")))
            {
                await userManager.AddToRoleAsync(normalUser, "User");
            }
        }
    }

}
