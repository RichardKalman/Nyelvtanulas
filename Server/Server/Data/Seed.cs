using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context,UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var roles = new List<AppRole>
            {
                new AppRole{Name = "Member"},
                new AppRole{Name = "Admin"},
                new AppRole{Name = "Moderator"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            var admin = new AppUser
            {
                UserName = "admin",
                Fullname="Admin",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var tmp  = await userManager.CreateAsync(admin, "adminPass123");
     
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });

        }
    }
}
