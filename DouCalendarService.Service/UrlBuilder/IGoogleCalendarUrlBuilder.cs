using System;
using System.Collections.Generic;
using System.Text;

namespace DouCalendarService.Service.UrlBuilder
{
    public interface IGoogleCalendarUrlBuilder
    {
        IGoogleCalendarUrlBuilder AddTitle(string title);

        IGoogleCalendarUrlBuilder AddDate(string date);

        IGoogleCalendarUrlBuilder AddLocation(string location);

        IGoogleCalendarUrlBuilder AddDetails(string details);

        string Build();
    }
}
