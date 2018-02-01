namespace Events.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // Seed initial data only if the database is empty
            if (!context.Users.Any())
            {
                var adminEmail = "admin@admin.com";
                var adminUserName = adminEmail;
                var adminFullName = "System Administrator";
                var adminPassword = adminEmail;
                string adminRole = "Administrator";
                CreateAdminUser(context, adminEmail, adminUserName, adminFullName, adminPassword, adminRole);
                CreateSeveralEvents(context);
            }
        }

        private void CreateAdminUser(ApplicationDbContext context, string adminEmail, string adminUserName, string adminFullName, string adminPassword, string adminRole)
        {
            // Create the "admin" user
            var adminUser = new ApplicationUser
            {
                UserName = adminUserName,
                FullName = adminFullName,
                Email = adminEmail
            };
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            var userCreateResult = userManager.Create(adminUser, adminPassword);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }

            // Create the "Administrator" role
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(adminRole));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            // Add the "admin" user to "Administrator" role
            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, adminRole);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }

        private void CreateSeveralEvents(ApplicationDbContext context)
        {
            context.Events.Add(new Event()
            {
                Title = "Party @ SoftUni",
                StartDateTime = DateTime.Now.Date.AddDays(5).AddHours(21).AddMinutes(30)
            });

            context.Events.Add(new Event()
            {
                Title = "Party <Again>",
                StartDateTime = DateTime.Now.Date.AddDays(7).AddHours(23).AddMinutes(00),
                Comments = new HashSet<Comment>() {
                    new Comment() { Text = "User comment", Author = context.Users.First() }
                }
            });

            context.Events.Add(new Event()
            {
                Title = "Another Party <Later>",
                StartDateTime = DateTime.Now.Date.AddDays(8).AddHours(22).AddMinutes(15)
            });

            context.Events.Add(new Event()
            {
                Title = "Passed Event <Anonymous>",
                StartDateTime = DateTime.Now.Date.AddDays(-2).AddHours(10).AddMinutes(30),
                Duration = TimeSpan.FromHours(1.5),
                Comments = new HashSet<Comment>() {
                    new Comment() { Text = "<Anonymous> comment" },
                    new Comment() { Text = "User comment", Author = context.Users.First() },
                    new Comment() { Text = "Another <user> comment", Author = context.Users.First() },
                    new Comment() { Text = "<Anonymous> comment" },
                    new Comment() { Text = "User comment", Author = context.Users.First() },
                    new Comment() { Text = "Another <user> comment", Author = context.Users.First() }
                }
            });

            context.Events.Add(new Event()
            {
                Title = "Passed Event <Again>",
                StartDateTime = DateTime.Now.Date.AddDays(-10).AddHours(18).AddMinutes(00),
                Duration = TimeSpan.FromHours(3),
            });

            context.Events.Add(new Event()
            {
                Title = "Passed Event",
                StartDateTime = DateTime.Now.Date.AddDays(-2).AddHours(12).AddMinutes(0),
                Author = context.Users.First(),
                Comments = new HashSet<Comment>() {
                    new Comment() { Text = "<Anonymous> comment" }
                }
            });

            context.Events.Add(new Event()
            {
                Title = "ASP.NET MVC Lab",
                StartDateTime = DateTime.Now.Date.AddDays(3).AddHours(11).AddMinutes(30),
                Author = context.Users.First(),
                Description = "This lab will focus on practical <ASP.NET MVC> Web application development",
                Duration = TimeSpan.FromHours(2),
                Location = "Software University (Sofia)",
                Comments = new HashSet<Comment>() {
                    new Comment() { Text = "<Anonymous> comment" },
                    new Comment() { Text = "User comment", Author = context.Users.First() },
                    new Comment() { Text = "Another <user> comment", Author = context.Users.First() }
                }
            });

            context.SaveChanges();
        }
    }
}
