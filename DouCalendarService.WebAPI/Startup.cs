using DouCalendarService.Service.Configuration;
using DouCalendarService.WebAPI.Infrastructure;
using DouCalendarService.WebAPI.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace DouCalendarService.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceConfig = Configuration.GetSection("service").Get<ServiceConfig>();
            services.AddSingleton(serviceConfig);

            services.AddHealthChecks();
            services.ConfigureCore();

            services.AddSwaggerService();
            services.AddClientsServices();
            services.AddJwtTokenAuthentication(serviceConfig);
            services.AddHttpClientService();
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime applicationLifetime)
        {
            app.UseHttpsRedirection();
            
            app.UseHealthChecks("/healthcheck");
            app.AddSwagger();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            applicationLifetime.ApplicationStarted.Register(() =>
            {
                Log.Information("{ServiceApiName} App has been started", DocumentationVariables.ServiceApiName);
            });
        }
    }
}
