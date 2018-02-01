using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Fruits.Web.IdentityData.DbContextExtensions
{
    public static class AppIdentityDbContextExtensions
    {
        public static void EnsureSeedData(this AppIdentityDbContext context)
        {
            if (context.AllMigrationsApplied())
            {
                if (!context.Subscriptions.Any())
                {
                    var platinum = new Subscription { Name = "platinum" };
                    context.Subscriptions.Add(platinum);
                    var gold = new Subscription { Name = "gold" };
                    context.Subscriptions.Add(gold);
                    var silver = new Subscription { Name = "silver" };
                    context.Subscriptions.Add(silver);

                    context.SaveChanges();
                }
            }
        }

        public static void EnsureRolesCreated(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<AppIdentityDbContext>();
            if (context.AllMigrationsApplied())
            {
                var roleManager = app.ApplicationServices.GetService<RoleManager<IdentityRole>>();
                foreach (var role in Roles.All)
                {
                    if (!roleManager.RoleExistsAsync(role.ToUpper()).Result)
                    {
                        roleManager.CreateAsync(new IdentityRole { Name = role });
                    }
                }
            }
        }

        public static async Task EnsureAdminCreated(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<AppIdentityDbContext>();
            if (context.AllMigrationsApplied())
            {
                var user = new User
                {
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    PhoneNumber = "+223366633352",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<User>();
                    var hashed = password.HashPassword(user, "password");
                    user.PasswordHash = hashed;
                    var userStore = new UserStore<User>(context);
                    await userStore.CreateAsync(user);

                    foreach (var role in Roles.All)
                    {
                        await userStore.AddToRoleAsync(user, role);
                    }
                }
            }
        }
    }
}
