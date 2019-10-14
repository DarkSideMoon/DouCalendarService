using DouCalendarService.Contracts.Attributes;
using System;

namespace DouCalendarService.Contracts.Events
{
    public class Event
    {
        /// <summary>
        /// Standard index of div elements
        /// </summary>
        public static readonly int IndexOfDiv = 3;

        /// <summary>
        /// Sometimes web site add advertise header 
        /// As a result, standard divs + 1 to get div of elements
        /// </summary>
        public static readonly int IndexOfDivWithHeader = IndexOfDiv + 1;

        /// <summary>
        /// Name of event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[{0}]/div[2]/div[2]/div[1]/h1")]
        public string Name { get; set; }

        /// <summary>
        /// Image logo of event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[{0}]/div[2]/div[2]/div[2]/img")]
        public string Image { get; set; }

        /// <summary>
        /// Date to pass event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[{0}]/div[2]/div[2]/div[2]/div[1]/div[2]")]
        public string Date { get; set; }

        /// <summary>
        /// Time to start event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[{0}]/div[2]/div[2]/div[2]/div[2]/div[2]")]
        public string Time { get; set; }

        /// <summary>
        /// Description of event
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Topic to relate event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[{0}]/div[2]/div[2]/div[3]")]
        public string Topics { get; set; }

        /// <summary>
        /// Count of visitors to go on event
        /// </summary>
        [XPathLocation("//*[@id=\"people\"]")]
        public string CountOfVisitors { get; set; }

        /// <summary>
        /// Cost of event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[{0}]/div[2]/div[2]/div[2]/div[4]/div[2]")]
        public string Cost { get; set; }

        /// <summary>
        /// Place to pass event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[{0}]/div[2]/div[2]/div[2]/div[3]/div[2]")]
        public string Location { get; set; }

        /// <summary>
        /// Count of views event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[{0}]/div[2]/div[2]/div[3]/span[2]")]
        public string CountOfViews { get; set; }

        /// <summary>
        /// Link of event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[{0}]/div[2]/div[2]/div[4]")]
        public string Link { get; set; }

        /// <summary>
        /// Start date time of event
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Finish date time of event
        /// </summary>
        public DateTime FinishDate { get; set; }

        public bool IsNullOrEmpty()
        {
            return string.IsNullOrEmpty(Name) 
                && string.IsNullOrEmpty(Date)
                && string.IsNullOrEmpty(Location);
        }
    }
}
