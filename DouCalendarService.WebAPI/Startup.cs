using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DouCalendarService.WebAPI.Infrastructure;
using DouCalendarService.WebAPI.Middleware;
using Serilog;
using DouCalendarService.Service.Configuration;

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
            var tokenConfig = Configuration.GetSection("tokenConfig")
                .Get<TokenConfig>();
            services.AddSingleton(tokenConfig);

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerService();
            services.AddClientsServices();
            services.AddJwtTokenAuthentication(tokenConfig);
        }

        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            IApplicationLifetime applicationLifetime)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", $"{DocumentationVariables.ServiceApiName} V1");
            });

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();
            app.UseMvc();

            applicationLifetime.ApplicationStarted.Register(() =>
            {
                Log.Information($"{DocumentationVariables.ServiceApiName} App has been started.");
            });
        }
    }
}
