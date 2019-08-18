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
    }
}
