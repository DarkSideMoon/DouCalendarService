using DouCalendarService.Model.Attributes;
using DouCalendarService.Model.Events;
using DouCalendarService.Parser.Dou;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DouCalendarService.Service
{
    public class DouService : IDouService
    {
        private DouHtmlParser _parser;

        public DouService(DouHtmlParser parser)
        {
            _parser = parser;
        }

        /// <summary>
        /// Initalize loading web page
        /// </summary>
        public async Task InitializeAsync() => await _parser.Load();

        /// <summary>
        /// Get count of events per page
        /// </summary>
        /// <returns></returns>
        public int GetCountOfEvents() => _parser.GetEventsCount();

        public IEnumerable<ShortEvent> GetShortEvents()
        {
            var shortEvents = new List<ShortEvent>();

            var eventsCount = GetCountOfEvents();
            for (int i = 1; i <= eventsCount; i++)
            {
                var shortEvent = new ShortEvent()
                {
                    Name = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Name), i)),
                    Place = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Place) ,i))
                };

                shortEvents.Add(shortEvent);
            }

            return shortEvents;
        }

        private string GetXPath<T>(Expression<Func<T, string>> func)
        {
            return AttributeHelper.GetValue(func);
        }
    }
}
