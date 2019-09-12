using DouCalendarService.Parser.Model;
using System;

namespace DouCalendarService.Parser
{
    public interface IDouDateTimeParser
    {
        DouDateTimeRange Parse(string date, string time);
    }
}
