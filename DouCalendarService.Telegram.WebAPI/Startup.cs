using DouCalendarService.Telegram.Service.Configuration;
using DouCalendarService.Telegram.WebAPI.Configuration;
using DouCalendarService.Telegram.WebAPI.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DouCalendarService.Telegram.WebAPI
{
    public class Startup
    {
        private const string _httpClientName = "httpService";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var config = Configuration.GetSection("service").Get<ServiceConfig>();
            services.AddSingleton(new DouCalendarMicroserviceConfig(config.MicroserviceUri));

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.ConfigureCore();

            services.AddTelegramBotClient(new TokenConfig
            {
                Token = ""
            },
            "");

            services.AddClientsServices();
            services.AddHttpClientService(_httpClientName);

            services.AddDouCalendarData();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.AddSupportedCultures();

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
