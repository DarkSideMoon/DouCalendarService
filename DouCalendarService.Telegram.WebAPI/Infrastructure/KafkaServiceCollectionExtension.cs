using DouCalendarService.Telegram.Service.Kafka;
using DouCalendarService.Telegram.Service.Model;
using DouCalendarService.Telegram.WebAPI.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DouCalendarService.Telegram.WebAPI.Infrastructure
{
    public static class KafkaServiceCollectionExtension
    {
        public static IServiceCollection AddKafkaEventMessageProducer(this IServiceCollection services, 
            KafkaConfiguration kafkaConfig)
        {
            services.AddSingleton(new KafkaSettings(
                kafkaConfig.BotEventProducer.Client, 
                kafkaConfig.BotEventProducer.Topic));
            services.AddSingleton<IBotEventMessageProducer, BotEventMessageProducer>();

            return services;
        }
    }
}
