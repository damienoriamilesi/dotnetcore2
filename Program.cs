using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace coreapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
            .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetupConfiguration)
                .UseUrls("http://localhost:5005")
                .UseStartup<Startup>()
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            // Removing Default config options
            builder.Sources.Clear();

            builder
                .AddJsonFile("appsettings.Development.json",false, true)
                .AddJsonFile("appsettings.json",false, true)
                // We can add different config from different files
                //.AddXmlFile("config.xml", true)
                .AddEnvironmentVariables();
        }
    }
}
