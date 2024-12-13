using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using static Freelancely.Web.Areas.Admin.AdminConstants;

namespace Freelancely.Web.Extensions
{
    public static class ApplicationBuilderExtentions
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scoupedServices = app.ApplicationServices.CreateScope();

            var services = scoupedServices.ServiceProvider;
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRoleName) == false)
            {
                var role = new IdentityRole(AdminRoleName);
                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync("admin@free.com");

                if (admin != null) 
                {
                    await userManager.AddToRoleAsync(admin, role.Name);                
                }
            }
        }
    }
}
