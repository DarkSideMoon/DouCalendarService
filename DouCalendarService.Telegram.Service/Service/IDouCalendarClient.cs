using System.Collections.Generic;
using System.Threading.Tasks;

namespace DouCalendarService.Telegram.Service.Service
{
    public interface IDouCalendarClient
    {
        Task<IEnumerable<string>> GetTopicTypesAsync();

        Task<IEnumerable<string>> GetLocationTypesAsync();
    }
}
