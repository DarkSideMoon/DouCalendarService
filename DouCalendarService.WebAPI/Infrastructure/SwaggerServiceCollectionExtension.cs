using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace DouCalendarService.WebAPI.Infrastructure
{
    public static class SwaggerServiceCollectionExtension
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = DocumentationVariables.ServiceApiName,
                    Description = "Dou calendar api to use from site dou.ua",
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT licenses",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });
            });

            return services;
        }
    }
}
