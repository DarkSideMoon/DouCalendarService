using DouCalendarService.Model.Events;
using DouCalendarService.Model.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DouCalendarService.Service.Dou
{
    public interface IDouService
    {
        Task<IEnumerable<ShortEvent>> GetEventsOnDay(DateTime dateTime);

        Task<IEnumerable<ShortEvent>> GetEventsByLocation(LocationType location);

        Task<IEnumerable<ShortEvent>> GetEventsByTopic(TopicType topic);
    }
}
