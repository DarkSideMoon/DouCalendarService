using System;
using System.Collections.Generic;
using System.Text;

namespace DouCalendarService.Model.Events
{
    public class Event : BaseEvent
    {
        /// <summary>
        /// Full description of event
        /// </summary>
        public EventDescription EventDescription { get; set; }

        /// <summary>
        /// Additional image
        /// </summary>
        public string AdditionalImage { get; set; }

        /// <summary>
        /// Count of views event
        /// </summary>
        public int CountOfViews { get; set; }

        /// <summary>
        /// Url to add event to google calender
        /// </summary>
        public string GoogleCalendar { get; set; }
    }
}
