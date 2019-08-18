using DouCalendarService.Model.Attributes;
using DouCalendarService.Model.Events;
using DouCalendarService.Model.Types;
using DouCalendarService.Parser;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DouCalendarService.Service.Dou
{
    public class DouService : IDouService
    {
        private readonly IDouHtmlParser _parser;

        public DouService(IDouHtmlParser parser)
        {
            _parser = parser;
        }

        /// <summary>
        /// Get evnts on specific day
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ShortEvent>> GetEventsOnDay(DateTime dateTime)
        {
            var url = string.Concat("", dateTime.Date.ToString());
            await _parser.LoadHtmlPage(url);

            return GetShortEvents();
        }

        /// <summary>
        /// Get events by location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ShortEvent>> GetEventsByLocation(LocationType location)
        {
            var url = string.Concat("", location.ToString());
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
            var url = string.Concat("", topic.ToString());
            await _parser.LoadHtmlPage("");

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
                Url = _parser.GetHrefValue(string.Format(GetXPath<ShortEvent>(x => x.Url), eventIndex)),
                Name = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Name), eventIndex)),
                Place = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Place), eventIndex)),
                Image = _parser.GetImage(string.Format(GetXPath<ShortEvent>(x => x.Image), eventIndex)),
                Date = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Date), eventIndex)),
                Description = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Description), eventIndex)),
                CountOfVisitors = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.CountOfVisitors), eventIndex)),
                Price = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Price), eventIndex)),
                //Topics = _parser.GetTags(string.Format(GetXPath<ShortEvent>(x => x.Topics), eventIndex))
            };
        }

        private string GetXPath<T>(Expression<Func<T, string>> func)
        {
            return AttributeHelper.GetValue(func);
        }
    }
}
