using DouCalendarService.Telegram.Service.Configuration;
using DouCalendarService.Telegram.WebAPI.Configuration;
using DouCalendarService.Telegram.WebAPI.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace DouCalendarService.Telegram.WebAPI
{
    public class Startup
    {
        private const string HttpClientName = "httpService";
        private const string ServiceSectionName = "service";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var config = Configuration.GetSection(ServiceSectionName).Get<ServiceConfig>();
            services.AddSingleton(new DouCalendarMicroserviceConfig(config.MicroserviceUri));

            services.ConfigureCore();

            services.AddTelegramBotClient(new TokenConfig
            {
                Token = ""
            },
            "");

            services.AddClientsServices();
            services.AddHttpClientService(HttpClientName);

            services.AddDouCalendarData();
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime applicationLifetime)
        {
            app.AddSupportedCultures();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            applicationLifetime.ApplicationStarted.Register(() =>
            {
                Log.Information("Telegram WebAPI has been started");
            });
        }
    }
}
