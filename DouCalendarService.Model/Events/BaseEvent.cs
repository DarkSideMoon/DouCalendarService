using System;
using System.Collections.Generic;
using System.Text;

namespace DouCalendarService.Model.Events
{
    public class BaseEvent
    {
        /// <summary>
        /// Name of event
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Image logo of event
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Date to pass event
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Description of event
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Topic to relate event
        /// </summary>
        public List<string> Topics { get; set; }

        /// <summary>
        /// Count of visitors to go on event
        /// </summary>
        public int CountOfVisitors { get; set; }

        /// <summary>
        /// Cost of event
        /// </summary>
        public string Cost { get; set; }

        /// <summary>
        /// Place to pass event
        /// </summary>
        public string Place { get; set; }
    }
}
