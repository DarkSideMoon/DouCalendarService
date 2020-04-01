﻿using DouCalendarService.WebAPI.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace DouCalendarService.WebAPI.Infrastructure
{
    public static class AspNetCoreServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureCore(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }

        public static IServiceCollection AddHttpClientService(this IServiceCollection services, string httpClientName)
        {
            services.AddHttpClient(httpClientName);
            services.AddTransient(x => x.GetRequiredService<IHttpClientFactory>().CreateClient(httpClientName));
            
            return services;
        }

        public static IServiceCollection AddHealthChecksService(this IServiceCollection services)
        {
            services.AddHealthChecks().AddCheck<DouSiteHealthCheck>("DouSite");

            return services;
        }
    }
}