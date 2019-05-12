using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DouCalendarService.Parser.Dou
{
    public class DouHtmlParser : HtmlParser
    {
        public DouHtmlParser(string url) : base(url)
        {
        }

        /// <summary>
        /// Get events count per one page
        /// </summary>
        /// <returns></returns>
        public int GetEventsCount()
        {
            var eventsXPath = "/html/body/div[1]/div[4]/div/div[2]/div/div/div[1]";
            var element = _htmlDocument.DocumentNode
                .SelectNodes(eventsXPath)
                .FirstOrDefault();

            return element.SelectNodes("article").Count;
        }
    }
}
