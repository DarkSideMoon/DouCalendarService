using System;
using System.Text;

namespace DouCalendarService.Service.UrlBuilder
{
    public class DouCalendarUrlBuilder : IDouCalendarUrlBuilder
    {
        private const string BaseUrl = "https://dou.ua/calendar/";

        private readonly StringBuilder _builder;

        public DouCalendarUrlBuilder()
        {
            _builder = new StringBuilder();
            _builder.Append(BaseUrl);
        }

        public IDouCalendarUrlBuilder AddCity(string city)
        {
            _builder.Append($"city/{city}");
            return this;
        }

        public IDouCalendarUrlBuilder AddDay(string day)
        {
            _builder.Append(day);
            return this;
        }

        public IDouCalendarUrlBuilder AddPage(string page)
        {
            _builder.Append($"page-{page}");
            return this;
        }

        public IDouCalendarUrlBuilder AddTag(string tag)
        {
            _builder.Append($"tags/{tag}");
            return this;
        }

        public IDouCalendarUrlBuilder AddTagWithCity(string city, string tag)
        {
            _builder.Append($"tags/{tag}/{city}");
            return this;
        }

        public string Build()
        {
            return _builder.ToString();
        }
    }
}
