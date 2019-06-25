using DouCalendarService.Model.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DouCalendarService.Service
{
    public interface IDouService
    {
        Task InitializeAsync();

        int GetCountOfEvents();

        IEnumerable<ShortEvent> GetShortEvents();
    }
}
