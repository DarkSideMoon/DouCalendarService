using DouCalendarService.Telegram.Service.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace DouCalendarService.Telegram.WebAPI.Infrastructure
{
    public static class TelegramServiceCollectionExtension
    {
        public static IServiceCollection AddTelegramBotClient(this IServiceCollection services, 
            TokenConfig tokenConfig,
            string serviceUrl)
        {
            var client = new TelegramBotClient(tokenConfig.Token);
            client.SetWebhookAsync(serviceUrl).Wait();

            services.AddSingleton(client);

            return services;
        }
    }
}
