using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;

using Fruits.Web.IdentityData.DbContextExtensions;

namespace Fruits.Web.IdentityData
{
    public class AdminSeeder
    {
        private AppIdentityDbContext context;

        public AdminSeeder(AppIdentityDbContext context)
        {
            this.context = context;
        }

        public async void SeedAdminUser()
        {
            if (context.AllMigrationsApplied())
            {
                var user = new User
                {
                    Country = "BG",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    PhoneNumber = "+223366633352",
                    //EmailConfirmed = true,
                    //PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<User>();
                    var hashed = password.HashPassword(user, "MySuperP@ss1");
                    user.PasswordHash = hashed;
                    var userStore = new UserStore<User>(context);
                    await userStore.CreateAsync(user);

                    foreach (var role in Roles.All)
                    {
                        await userStore.AddToRoleAsync(user, role);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
