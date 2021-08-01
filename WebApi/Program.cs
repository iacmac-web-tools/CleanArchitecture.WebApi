using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Identity.Models;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Contexts;

namespace WebApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var identityContext = services.GetRequiredService<IdentityContext>();
                    await identityContext.Database.MigrateAsync();

                    var persistenceContext = services.GetRequiredService<ApplicationDbContext>();
                    await persistenceContext.Database.MigrateAsync();

                    Log.Information("Migrations Applied");
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, "An error occurred migrating the DB");
                }
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    await Infrastructure.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                    await Infrastructure.Identity.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
                    await Infrastructure.Identity.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);
                    Log.Information("Finished Seeding Default Data");
                    Log.Information("Application Starting");
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, "An error occurred seeding the DB");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog() //Uses Serilog instead of default .NET Logger
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls(Environment.GetEnvironmentVariable("ASPNETCORE_URLS"));
                    webBuilder.UseKestrel(options =>{options.Limits.MaxRequestBodySize = 209715200;});

                    webBuilder.UseStartup<Startup>();
                });
    }
}
