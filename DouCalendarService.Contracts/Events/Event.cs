using DouCalendarService.Contracts.Attributes;
using System.Collections.Generic;

namespace DouCalendarService.Contracts.Events
{
    public class Event
    {
        /// <summary>
        /// Name of event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[2]/div[2]/div[2]/div[1]/h1")]
        public string Name { get; set; }

        /// <summary>
        /// Image logo of event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/img")]
        public string Image { get; set; }

        /// <summary>
        /// Date to pass event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[2]")]
        public string Date { get; set; }

        /// <summary>
        /// Description of event
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Topic to relate event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[2]/div[2]/div[2]/div[3]")]
        public List<string> Topics { get; set; }

        /// <summary>
        /// Count of visitors to go on event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[4]//*[@id=\"people\"]")]
        public int CountOfVisitors { get; set; }

        /// <summary>
        /// Cost of event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[3]/div[2]")]
        public string Cost { get; set; }

        /// <summary>
        /// Place to pass event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[2]/div[2]")]
        public string Location { get; set; }

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
        [XPathLocation("/html/body/div[1]/div[2]/div[2]/div[2]/div[3]/span[2]")]
        public int CountOfViews { get; set; }

        /// <summary>
        /// Link of event
        /// </summary>
        [XPathLocation("/html/body/div[1]/div[2]/div[2]/div[2]/div[4]")]
        public string Link { get; set; }

        public bool IsNullOrEmpty()
        {
            return string.IsNullOrEmpty(Name) 
                && string.IsNullOrEmpty(Date)
                && string.IsNullOrEmpty(Location);
        }
    }
}
