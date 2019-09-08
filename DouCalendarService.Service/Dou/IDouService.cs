using DouCalendarService.Contracts.Events;
using DouCalendarService.Contracts.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DouCalendarService.Service.Dou
{
    public interface IDouService
    {
        Task<Event> GetEventById(string id);

        Task<IEnumerable<ShortEvent>> GetEventsOnDay(string dateTime);

        Task<IEnumerable<ShortEvent>> GetEventsByLocation(LocationType locationType);

        Task<IEnumerable<ShortEvent>> GetEventsByTopic(TopicType topic);

        Task<string> CreateGoogleLink(string id);
    }
}
