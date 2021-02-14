using DouCalendarService.Contracts.Events;
using DouCalendarService.Contracts.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DouCalendarService.Service.Dou
{
    public interface IDouService
    {
        Task<Event> GetEventById(string id);

        Task<IEnumerable<ShortEvent>> GetEventsOnDay(string dateTime, int? page, int? count);

        Task<IEnumerable<ShortEvent>> GetEventsByLocation(LocationType locationType, int? page, int? count);

        Task<IEnumerable<ShortEvent>> GetEventsByTopic(TopicType topic, int? page, int? count);

        Task<string> CreateGoogleLink(string id);
    }
}
