using DouCalendarService.Telegram.Service.Bot;
using DouCalendarService.Telegram.Service.Buttons;
using DouCalendarService.Telegram.Service.MessageBuilder;
using DouCalendarService.Telegram.Service.Service;
using DouCalendarService.Telegram.WebAPI.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace DouCalendarService.Telegram.WebAPI.Infrastructure
{
    public static class ClientsServiceCollectionExtension
    {
        public static IServiceCollection AddClientsServices(this IServiceCollection services)
        {
            services.AddTransient<IBotService, BotService>();
            services.AddTransient<IInlineButtonsBuilder, InlineButtonsBuilder>();
            services.AddTransient<IDouCalendarClient, DouCalendarClient>();
            services.AddTransient<IDouMessageBuilder, DouMessageBuilder>();

            services.AddTransient<IStringLocalizer, BotStringLocalizer>();

            return services;
        }
    }
}
