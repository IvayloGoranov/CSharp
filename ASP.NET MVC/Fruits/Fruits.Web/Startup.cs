using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using Fruits.Web.IdentityData;
using Fruits.Data;
using Fruits.Data.Interfaces;
using Fruits.Data.Repositories;
using Fruits.Web.IdentityData.Interfaces;
using Fruits.Web.IdentityData.Repositories;
using Fruits.Web.IdentityData.DbContextExtensions;
using Microsoft.AspNetCore.Http;

namespace Fruits.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IFruitsContext>(context => 
                    new FruitsContext(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add CookieTempDataProvider after AddMvc and include ViewFeatures.
            // using Microsoft.AspNetCore.Mvc.ViewFeatures;
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

            // Add application services.
            services.AddTransient<AdminSeeder>();
            services.AddScoped<IAppIdentityDbContext, AppIdentityDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IEfCoreRepository<>), typeof(EFCoreRepository<>));
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, AdminSeeder adminSeeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();

                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<AppIdentityDbContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<AppIdentityDbContext>().EnsureSeedData();
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();
            app.EnsureRolesCreated();
            adminSeeder.SeedAdminUser();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LoginPath = new PathString("/Account/Login")
            });

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
