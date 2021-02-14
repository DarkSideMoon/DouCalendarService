using DouCalendarService.Parser;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;

namespace DouCalendarService.WebAPI.Infrastructure
{
    public static class AspNetCoreServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureCore(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));

            return services;
        }

        public static IServiceCollection AddHttpClientService(this IServiceCollection services)
        {
            services.AddHttpClient<IDouHtmlParser, DouHtmlParser>();
            return services;
        }
    }
}
