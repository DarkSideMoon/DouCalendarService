using DouCalendarService.Service.Extensions;
using System;
using System.Collections.Specialized;
using System.Text;

namespace DouCalendarService.Service.UrlBuilder
{
    public class GoogleCalendarUrlBuilder : IGoogleCalendarUrlBuilder
    {
        private const string BaseUrl = "https://calendar.google.com/calendar/r/eventedit";
        private const string TitileKey = "text";
        private const string DatesKey = "dates";
        private const string LocationKey = "location";
        private const string DetailsKey = "details";
        private const string TrpKey = "trp";

        private readonly StringBuilder _builder;
        private readonly NameValueCollection _queryString;

        public GoogleCalendarUrlBuilder()
        {
            _builder = new StringBuilder(BaseUrl);
            _queryString = new NameValueCollection();
        }

        public IGoogleCalendarUrlBuilder AddDateTime(DateTime startDate, DateTime finishDate)
        {
            _queryString.Add(DatesKey, $"{startDate.ToDouDateTime()}/{finishDate.ToDouDateTime()}");
            return this;
        }

        public IGoogleCalendarUrlBuilder AddLocation(string location)
        {
            _queryString.Add(LocationKey, location);
            return this;
        }

        public IGoogleCalendarUrlBuilder AddTitle(string title)
        {
            _queryString.Add(TitileKey, title);
            return this;
        }

        public IGoogleCalendarUrlBuilder AddDetails(string details)
        {
            _queryString.Add(DetailsKey, details);
            return this;
        }

        public string Build()
        {
            _queryString.Add(TrpKey, "false");

            _builder.Append(_queryString.ToQueryString());
            return _builder.ToString();
        }
    }
}
