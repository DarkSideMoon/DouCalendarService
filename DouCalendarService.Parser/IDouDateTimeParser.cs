using DouCalendarService.Parser.Model;

namespace DouCalendarService.Parser
{
    public interface IDouDateTimeParser
    {
        DouDateTimeRange Parse(string date, string time);
    }
}
