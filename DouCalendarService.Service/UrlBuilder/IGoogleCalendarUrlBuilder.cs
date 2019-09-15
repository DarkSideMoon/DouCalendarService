using System;
using System.Collections.Generic;
using System.Text;

namespace DouCalendarService.Service.UrlBuilder
{
    public interface IGoogleCalendarUrlBuilder
    {
        IGoogleCalendarUrlBuilder AddTitle(string title);

        IGoogleCalendarUrlBuilder AddDateTime(DateTime startDate, DateTime finishDate);

        IGoogleCalendarUrlBuilder AddLocation(string location);

        IGoogleCalendarUrlBuilder AddDetails(string details);

        string Build();
    }
}
