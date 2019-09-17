using DouCalendarService.Contracts.Attributes;
using DouCalendarService.Contracts.Events;
using DouCalendarService.Contracts.Exceptions;
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
        private const string EventNotFoundMessage = "Event with id {0} not found!";
        private const string GoogleLinkDetailsMessage = "Dou event: {0} {1}";

        private readonly IDouHtmlParser _parser;
        private readonly IDouCalendarUrlBuilder _urlBuilder;
        private readonly IGoogleCalendarUrlBuilder _googleUrlBuilder;

        public DouService(IDouHtmlParser parser, 
            IDouCalendarUrlBuilder urlBuilder,
            IGoogleCalendarUrlBuilder googleUrlBuilde)
        {
            _parser = parser;
            _urlBuilder = urlBuilder;
            _googleUrlBuilder = googleUrlBuilde;
        }

        /// <summary>
        /// Get event by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Event> GetEventById(string id)
        {
            var url = _urlBuilder
                .AddId(id)
                .Build();

            await _parser.LoadHtmlPage(url);
            var douEvent = GetEvent();

            if (douEvent.IsNullOrEmpty())
                throw new EventNotFoundException(string.Format(EventNotFoundMessage, id));

            return douEvent;
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
        /// Get google link
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> CreateGoogleLink(string id)
        {
            var douEvent = await GetEventById(id);

            if (douEvent.IsNullOrEmpty())
                throw new EventNotFoundException(string.Format(EventNotFoundMessage, id));

            return _googleUrlBuilder
                .AddTitle(douEvent.Name)
                .AddDateTime(douEvent.StartDate, douEvent.FinishDate)
                .AddLocation(douEvent.Location)
                .AddDetails(string.Format(GoogleLinkDetailsMessage, douEvent.Name, douEvent.Link))
                .Build();
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
                var shortEvent = GetShortEvent(i);
                shortEvents.Add(shortEvent);
            }

            return shortEvents;
        }

        /// <summary>
        /// Get short event by index in html
        /// </summary>
        /// <param name="eventIndex"></param>
        /// <returns></returns>
        private ShortEvent GetShortEvent(int eventIndex)
        {
            return new ShortEvent
            {
                Id = _parser.GetIdValue(string.Format(GetXPath<ShortEvent>(x => x.Url), eventIndex)),
                Url = _parser.GetHrefValue(string.Format(GetXPath<ShortEvent>(x => x.Url), eventIndex)),
                Name = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Name), eventIndex)),
                Place = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Place), eventIndex)),
                Image = _parser.GetImage(string.Format(GetXPath<ShortEvent>(x => x.Image), eventIndex)),
                Date = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Date), eventIndex)),
                Description = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Description), eventIndex)),
                CountOfVisitors = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.CountOfVisitors), eventIndex)),
                Price = _parser.GetValue(string.Format(GetXPath<ShortEvent>(x => x.Price), eventIndex)),
                Topics = _parser.GetTags(string.Format(GetXPath<ShortEvent>(x => x.Topics), eventIndex))
            };
        }

        /// <summary>
        /// Get full event
        /// </summary>
        /// <returns></returns>
        private Event GetEvent()
        {
            var indexOfDivElement = Event.IndexOfDiv;

            if (_parser.IsHasAdvertiseHeader())
                indexOfDivElement = Event.IndexOfDivWithHeader;

            var date = _parser.GetValue(string.Format(GetXPath<Event>(x => x.Date), indexOfDivElement));
            var time = _parser.GetValue(string.Format(GetXPath<Event>(x => x.Time), indexOfDivElement));

            var dateTimeOfEvent = _parser.GetDouDateTime(date, time);
            return new Event
            {
                Name = _parser.GetValue(string.Format(GetXPath<Event>(x => x.Name), indexOfDivElement)),
                Date = date,
                Time = time,
                Location = _parser.GetValue(string.Format(GetXPath<Event>(x => x.Location), indexOfDivElement)),
                Link = _parser.GetParsedUrl(string.Format(GetXPath<Event>(x => x.Link), indexOfDivElement)),
                Cost = _parser.GetValue(string.Format(GetXPath<Event>(x => x.Cost), indexOfDivElement)),
                CountOfViews = _parser.GetValue(string.Format(GetXPath<Event>(x => x.CountOfViews), indexOfDivElement)),
                CountOfVisitors = _parser.GetCountOfEventVisitors(string.Format(GetXPath<Event>(x => x.CountOfVisitors), indexOfDivElement)),
                Topics = _parser.GetTags(string.Format(GetXPath<Event>(x => x.Topics), indexOfDivElement)),
                Image = _parser.GetImage(string.Format(GetXPath<Event>(x => x.Image), indexOfDivElement)),
                StartDate = dateTimeOfEvent.StartDate,
                FinishDate = dateTimeOfEvent.FinishDate
            };
        }

        private static string GetXPath<T>(Expression<Func<T, string>> func)
        {
            return AttributeHelper.GetXPathLocationValue(func);
        }
    }
}
