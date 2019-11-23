using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DouCalendarService.WebAPI
{
    public class Program
    {
        private static string _environmentName;

        public static void Main(string[] args)
        {
            var webHost = CreateWebHost(args);

            var configiration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{_environmentName}.json", optional: true, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configiration)
                .CreateLogger();

            webHost.Run();
        }

        public static IWebHost CreateWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .ConfigureLogging((hostingContext, config) =>
             {
                 config.ClearProviders();
                 _environmentName = hostingContext.HostingEnvironment.EnvironmentName;
             })
            .UseStartup<Startup>()
            .UseSerilog()
            .Build();
    }
}
