﻿using DouCalendarService.Model.Attributes;
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
        [XPathLocation("/html/body/div[1]/div[4]/div/div[2]/div/div/div[1]/article[1]/h2/a")]
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
