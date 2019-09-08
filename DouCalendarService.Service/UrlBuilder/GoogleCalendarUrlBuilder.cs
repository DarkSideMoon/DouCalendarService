﻿using DouCalendarService.Service.Extensions;
using System.Collections.Specialized;
using System.Text;

namespace DouCalendarService.Service.UrlBuilder
{
    public class GoogleCalendarUrlBuilder : IGoogleCalendarUrlBuilder
    {
        private const string BaseUrl = "https://calendar.google.com/calendar/r/eventedit?";
        private const string TitileKey = "text";
        private const string DatesKey = "dates";
        private const string LocationKey = "location";
        private const string DetailsKey = "details";

        private readonly StringBuilder _builder;
        private readonly NameValueCollection _queryString;

        public GoogleCalendarUrlBuilder()
        {
            _builder = new StringBuilder(BaseUrl);
            _queryString = new NameValueCollection();
        }

        public IGoogleCalendarUrlBuilder AddDates(string startDate, string finishDate)
        {
            _queryString.Add(TitileKey, $"{startDate}/{finishDate}");
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

        public IGoogleCalendarUrlBuilder Details(string details)
        {
            _queryString.Add(DetailsKey, details);
            return this;
        }

        public string Build()
        {
            _builder.Append(_queryString.ToQueryString());
            return _builder.ToString();
        }
    }
}
