using DouCalendarService.Model.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DouCalendarService.Service.Dou
{
    public interface IDouService
    {
        Task InitializeAsync();

        int GetCountOfEvents();

        ShortEvent GetFirstEvent();

        IEnumerable<ShortEvent> GetShortEvents();

        string GetMessageEvent();

        IEnumerable<string> GetMessageEvents();
    }
}
