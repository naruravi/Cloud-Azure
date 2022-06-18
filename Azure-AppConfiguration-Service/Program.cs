using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Azure_AppConfiguration_Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                        var settings = config.Build();
                        config.AddAzureAppConfiguration("Endpoint=https://appconfig8681.azconfig.io;Id=wTUn-l0-s0:jPl40F8zd9uQfQS2WfB4;Secret=8mVbUhBs5/GfsgrbmgJJ5J6OwMyUvoVPhVgNO6GdK04=");
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
