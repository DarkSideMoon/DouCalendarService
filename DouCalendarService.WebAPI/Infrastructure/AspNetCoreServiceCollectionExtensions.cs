using DouCalendarService.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace DouCalendarService.WebAPI.Infrastructure
{
    public static class AspNetCoreServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureCore(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }

        public static IServiceCollection AddHttpClientService(this IServiceCollection services)
        {
            services.AddHttpClient<IDouHtmlParser, DouHtmlParser>();
            return services;
        }
    }
}
