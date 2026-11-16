using Microsoft.AspNetCore.Identity;
using PokestopHotSpots.Models;

namespace PokestopHotSpots.Data;

// Runs once, when the app starts. Makes sure the Admin role exists, then
// gives it to the user whose email is in configuration under Admin:Email —
// a user secret on my machine, an app setting on Azure. No email set, or
// nobody has registered with it yet: the role exists, and nobody holds it.
public static class RoleSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var config = services.GetRequiredService<IConfiguration>();

        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        var email = config["Admin:Email"];
        if (string.IsNullOrEmpty(email))
        {
            return;
        }

        var user = await userManager.FindByEmailAsync(email);
        if (user != null && !await userManager.IsInRoleAsync(user, "Admin"))
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}