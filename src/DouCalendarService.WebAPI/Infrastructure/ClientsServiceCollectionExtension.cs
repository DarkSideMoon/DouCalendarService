using DouCalendarService.Parser;
using DouCalendarService.Service.Dou;
using DouCalendarService.Service.Security;
using DouCalendarService.Service.UrlBuilder;
using Microsoft.Extensions.DependencyInjection;

namespace DouCalendarService.WebAPI.Infrastructure
{
    public static class ClientsServiceCollectionExtension
    {
        public static IServiceCollection AddClientsServices(this IServiceCollection services)
        {
            services.AddTransient<IDouDateTimeParser, DouDateTimeParser>();
            services.AddTransient<IDouHtmlParser, DouHtmlParser>();
            services.AddTransient<IDouCalendarUrlBuilder, DouCalendarUrlBuilder>();
            services.AddTransient<IGoogleCalendarUrlBuilder, GoogleCalendarUrlBuilder>();
            services.AddTransient<IDouService, DouService>();
            services.AddTransient<ITokenManagementService, TokenManagementService>();

            return services;
        }
    }
}
