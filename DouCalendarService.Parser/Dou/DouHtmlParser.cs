using System.Linq;

namespace DouCalendarService.Parser.Dou
{
    public class DouHtmlParser : HtmlParser
    {
        private const string EventsCountXPath = "/html/body/div[1]/div[4]/div/div[2]/div/div/div[1]";

        public DouHtmlParser(string url) : base(url)
        {
        }

        /// <summary>
        /// Get events count per one page
        /// </summary>
        /// <returns></returns>
        public int GetEventsCount()
        {
            var element = _htmlDocument.DocumentNode
                .SelectNodes(EventsCountXPath)
                .FirstOrDefault();

            return element.SelectNodes("article").Count;
        }

        /// <summary>
        /// Parse html content to get tags of event
        /// </summary>
        /// <returns></returns>
        public string GetTags(string xpath)
        {
            var html = _htmlDocument.DocumentNode
                .SelectNodes(xpath)
                .FirstOrDefault();

            if(html != null)
            {
                var childs = html.ChildNodes
                    .Where(x => x.Name == "a")
                    .ToList();

                return string.Join(";", childs.Select(x => x.InnerHtml).ToList());
            }

            return string.Empty;
        }
    }
}
