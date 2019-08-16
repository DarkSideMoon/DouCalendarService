using DouCalendarService.Model.Attributes;
using DouCalendarService.Model.Events;
using DouCalendarService.Parser.Dou;
using DouCalendarService.Service.Builder;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DouCalendarService.Service.Dou
{
    public class DouService : IDouService
    {
        private const int FirstEvent = 1;

        private readonly DouHtmlParser _parser;
        private readonly IMessageBuilder _messageBuilder;

        public DouService(DouHtmlParser parser, IMessageBuilder messageBuilder)
        {
            _parser = parser;
            _messageBuilder = messageBuilder;
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

        /// <summary>
        /// Get information about all short events on page
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ShortEvent> GetShortEvents()
        {
            var shortEvents = new List<ShortEvent>();

            var eventsCount = GetCountOfEvents();
            for (int i = 1; i <= eventsCount; i++)
            {
                var shortEvent = GetEvent(i);
                shortEvents.Add(shortEvent);
            }

            return shortEvents;
        }

        /// <summary>
        /// Get information about first short event on page
        /// </summary>
        /// <returns></returns>
        public ShortEvent GetFirstEvent()
        {
            return GetEvent(FirstEvent);
        }

        /// <summary>
        /// Get mesage format of event
        /// </summary>
        /// <returns></returns>
        public string GetMessageEvent()
        {
            var douEvent = GetFirstEvent();

            _messageBuilder.AddCaption(douEvent.Name);
            _messageBuilder.AddTime(douEvent.Date);
            _messageBuilder.AddMainText(douEvent.Description);
            _messageBuilder.AddPlace(douEvent.Place);
            _messageBuilder.AddPrice(douEvent.Price);
            _messageBuilder.AddLink(douEvent.Url);

            return _messageBuilder.Build();
        }

        public IEnumerable<string> GetMessageEvents()
        {
            var events = new List<string>();
            foreach (var douEvent in GetShortEvents())
            {
                _messageBuilder.AddCaption(douEvent.Name);
                _messageBuilder.AddTime(douEvent.Date);
                _messageBuilder.AddPlace(douEvent.Place);
                _messageBuilder.AddPrice(douEvent.Price);

                _messageBuilder.NewLine();

                events.Add(_messageBuilder.Build());
            }
            return events;
        }

        private string GetXPath<T>(Expression<Func<T, string>> func)
        {
            return AttributeHelper.GetValue(func);
        }

        private ShortEvent GetEvent(int eventNumber)
        {
            return new ShortEvent()
            {
                Url = _parser.GetHrefValue(string.Format(GetXPath<ShortEvent>(x => x.Url), eventNumber)),
                Name = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Name), eventNumber)),
                Place = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Place), eventNumber)),
                Image = _parser.GetImage(string.Format(GetXPath<ShortEvent>(x => x.Image), eventNumber)),
                Date = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Date), eventNumber)),
                Description = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Description), eventNumber)),
                CountOfVisitors = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.CountOfVisitors), eventNumber)),
                Price = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Price), eventNumber)),
                //Topics = _parser.GetTags(string.Format(GetXPath<ShortEvent>(x => x.Topics), eventNumber))
            };
        }
    }
}
