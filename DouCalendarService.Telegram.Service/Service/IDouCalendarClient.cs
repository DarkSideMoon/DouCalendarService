using DouCalendarService.Telegram.Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DouCalendarService.Telegram.Service.Service
{
    public interface IDouCalendarClient
    {
        Task<IEnumerable<string>> GetTopicTypesAsync();

        Task<IEnumerable<string>> GetLocationTypesAsync();

        Task<IEnumerable<ShortEvent>> GetEventsByDateAsync(string date);

        Task<IEnumerable<ShortEvent>> GetEventsByTopicAsync(string topic);

        Task<IEnumerable<ShortEvent>> GetEventsByLocationAsync(string location);

        Task<string> GetGoogleCalendarLink(string id);
    }
}
