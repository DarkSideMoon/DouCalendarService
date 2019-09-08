using System;
using System.Collections.Generic;
using System.Text;

namespace DouCalendarService.Service.UrlBuilder
{
    public interface IGoogleCalendarUrlBuilder
    {
        IGoogleCalendarUrlBuilder AddTitle(string title);

        IGoogleCalendarUrlBuilder AddDates(string startDate, string finishDate);

        IGoogleCalendarUrlBuilder AddLocation(string location);

        IGoogleCalendarUrlBuilder Details(string details);

        string Build();
    }
}
