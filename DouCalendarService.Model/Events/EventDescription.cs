using System;
using System.Collections.Generic;
using System.Text;

namespace DouCalendarService.Model.Events
{
    public class EventDescription
    {
        /// <summary>
        /// Full text of event description
        /// </summary>
        public string FullText { get; set; }

        /// <summary>
        /// Paragraphs from text
        /// </summary>
        public List<string> Paragraphs { get; set; }

        /// <summary>
        /// Links from text
        /// </summary>
        public List<string> Links { get; set; }
    }
}
