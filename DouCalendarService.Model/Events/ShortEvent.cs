﻿using DouCalendarService.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DouCalendarService.Model.Events
{
    public class ShortEvent
    {
        /// <summary>
        /// Name of event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[4]/div/div[2]/div/div/div[1]/article[{0}]/h2/a")]
        public string Name { get; set; }

        /// <summary>
        /// Image logo of event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[4]/div/div[2]/div/div/div[1]/article[{0}]/h2/a/img[@src]")]
        public string Image { get; set; }

        /// <summary>
        /// Date to pass event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[4]/div/div[2]/div/div/div[1]/article[{0}]/div[1]/span[1]")]
        public string Date { get; set; }

        /// <summary>
        /// Description of event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[4]/div/div[2]/div/div/div[1]/article[{0}]/p")]
        public string Description { get; set; }

        /// <summary>
        /// Topic to relate event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[4]/div/div[2]/div/div/div[1]/article[{0}]/div[2]")]
        public string Topics { get; set; }

        /// <summary>
        /// Count of visitors to go on event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[4]/div/div[2]/div/div/div[1]/article[{0}]/div[2]/span")]
        public string CountOfVisitors { get; set; }

        /// <summary>
        /// Cost of event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[4]/div/div[2]/div/div/div[1]/article[{0}]/div[1]/span[2]")]
        public string Cost { get; set; }

        /// <summary>
        /// Place to pass event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[4]/div/div[2]/div/div/div[1]/article[{0}]/div[1]/text()[2]")]
        public string Place { get; set; }
    }
}
