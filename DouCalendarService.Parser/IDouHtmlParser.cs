using DouCalendarService.Parser.Model;
using System.Threading.Tasks;

namespace DouCalendarService.Parser
{
    public interface IDouHtmlParser
    {
        Task LoadHtmlPage(string url);

        int GetEventsCount();

        string GetTags(string xpath);

        string GetValue(string xpath);

        string GetHrefValue(string xpath);

        string GetImage(string xpath);

        string GetIdValue(string xpath);

        string GetParsedUrl(string xpath);

        string GetCountOfEventVisitors(string xpath);

        DouDateTimeRange GetDouDateTime(string date, string time);

        bool IsHasAdvertiseHeader();
    }
}
