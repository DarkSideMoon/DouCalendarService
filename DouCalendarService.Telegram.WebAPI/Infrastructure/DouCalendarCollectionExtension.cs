using DouCalendarService.Telegram.Service.Model;
using DouCalendarService.Telegram.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace DouCalendarService.Telegram.WebAPI.Infrastructure
{
    public static class DouCalendarCollectionExtension
    {
        public static IServiceCollection AddDouCalendarData(this IServiceCollection services)
        {
            var douCalendarClient = services.BuildServiceProvider().GetService<IDouCalendarClient>();
            var topics = Task.Run(async () => await douCalendarClient.GetTopicTypesAsync().ConfigureAwait(true)).Result;
            var locations = Task.Run(async () => await douCalendarClient.GetLocationTypesAsync().ConfigureAwait(true)).Result;

            services.AddSingleton(new DouCalendarSetting(topics, locations, true));
            return services;
        }
    }
}
