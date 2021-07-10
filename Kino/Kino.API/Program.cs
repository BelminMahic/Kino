using Kino.API.Database;
using Kino.API.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hosts = CreateHostBuilder(args).Build();

            using (var scope = hosts.Services.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<KinotekaDbContext>();
                service.Database.Migrate();
                Seeding.SeedDatabase(service);
            }

            hosts.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
