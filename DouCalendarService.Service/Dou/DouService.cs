using DouCalendarService.Contracts.Attributes;
using DouCalendarService.Contracts.Events;
using DouCalendarService.Contracts.Types;
using DouCalendarService.Parser;
using DouCalendarService.Service.UrlBuilder;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DouCalendarService.Service.Dou
{
    public class DouService : IDouService
    {
        private const string DateTimeFormat = "yyyy-MM-dd";

        private readonly IDouHtmlParser _parser;
        private readonly IDouCalendarUrlBuilder _urlBuilder;

        public DouService(IDouHtmlParser parser, IDouCalendarUrlBuilder urlBuilder)
        {
            _parser = parser;
            _urlBuilder = urlBuilder;
        }

        /// <summary>
        /// Get evnts on specific day
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ShortEvent>> GetEventsOnDay(string dateTime)
        {
            DateTime.TryParse(dateTime, out var date);

            var url = _urlBuilder
                .AddDay(date.ToString(DateTimeFormat))
                .Build();
            await _parser.LoadHtmlPage(url);

            return GetShortEvents();
        }

        /// <summary>
        /// Get events by location
        /// </summary>
        /// <param name="locationType"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ShortEvent>> GetEventsByLocation(LocationType locationType)
        {
            var url = _urlBuilder
                .AddCity(AttributeHelper.GetEnumMemberValue(locationType, typeof(LocationType)))
                .Build();
            await _parser.LoadHtmlPage(url);

            return GetShortEvents();
        }

        /// <summary>
        /// Get events by topic
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ShortEvent>> GetEventsByTopic(TopicType topic)
        {
            var url = _urlBuilder
                .AddTag(AttributeHelper.GetEnumMemberValue(topic, typeof(TopicType)))
                .Build();
            await _parser.LoadHtmlPage(url);

            return GetShortEvents();
        }

        /// <summary>
        /// Get information about all short events on page
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ShortEvent> GetShortEvents()
        {
            var shortEvents = new List<ShortEvent>();

            var eventsCount = _parser.GetEventsCount();
            for (int i = 1; i <= eventsCount; i++)
            {
                var shortEvent = GetEvent(i);
                shortEvents.Add(shortEvent);
            }

            return shortEvents;
        }

        /// <summary>
        /// Get event by index in html
        /// </summary>
        /// <param name="eventIndex"></param>
        /// <returns></returns>
        private ShortEvent GetEvent(int eventIndex)
        {
            return new ShortEvent()
            {
                Url = _parser.GetHrefValue(string.Format(GetXPath(x => x.Url), eventIndex)),
                Name = _parser.GetValue(string.Format(GetXPath(x => x.Name), eventIndex)),
                Place = _parser.GetValue(string.Format(GetXPath(x => x.Place), eventIndex)),
                Image = _parser.GetImage(string.Format(GetXPath(x => x.Image), eventIndex)),
                Date = _parser.GetValue(string.Format(GetXPath(x => x.Date), eventIndex)),
                Description = _parser.GetValue(string.Format(GetXPath(x => x.Description), eventIndex)),
                CountOfVisitors = _parser.GetValue(string.Format(GetXPath(x => x.CountOfVisitors), eventIndex)),
                Price = _parser.GetValue(string.Format(GetXPath(x => x.Price), eventIndex)),
                Topics = _parser.GetTags(string.Format(GetXPath(x => x.Topics), eventIndex))
            };
        }

        private string GetXPath(Expression<Func<ShortEvent, string>> func)
        {
            return AttributeHelper.GetXPathLocationValue(func);
        }
    }
}
