using DouCalendarService.Telegram.Service.Bot;
using DouCalendarService.Telegram.Service.Buttons;
using DouCalendarService.Telegram.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DouCalendarService.Telegram.WebAPI.Infrastructure
{
    public static class ClientsServiceCollectionExtension
    {
        public static IServiceCollection AddClientsServices(this IServiceCollection services)
        {
            services.AddTransient<IBotService, BotService>();
            services.AddTransient<IInlineButtonsBuilder, InlineButtonsBuilder>();
            services.AddTransient<IDouCalendarClient, DouCalendarClient>();

            return services;
        }
    }
}
