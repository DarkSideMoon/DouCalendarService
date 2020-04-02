using DouCalendarService.Telegram.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DouCalendarService.Telegram.WebAPI.Infrastructure
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
            services.AddHttpClient<IDouCalendarClient, DouCalendarClient>();

            return services;
        }
    }
}
