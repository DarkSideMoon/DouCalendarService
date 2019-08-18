using HtmlAgilityPack;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DouCalendarService.Parser
{
    public class DouHtmlParser : IDouHtmlParser
    {
        private const string EventsCountXPath = "/html/body/div[1]/div[3]/div/div[2]/div/div/div[1]";
        private const string ArticleNode = "article";
        private const string ChildHrefNode = "a";
        private const string ChildHrefSeperatorNode = ";";
        private const string HrefNode = "href";
        private const string ImageNode = "src";

        private HtmlDocument _htmlDocument;

        public DouHtmlParser()
        {
            _htmlDocument = new HtmlDocument();
        }

        /// <summary>
        /// Load html page to HtmlDocument
        /// </summary>
        /// <returns></returns>
        public async Task LoadHtmlPage(string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    var result = await response.Content.ReadAsStringAsync();
                    _htmlDocument.LoadHtml(result);
                }
            }
        }

        /// <summary>
        /// Get count of events on page
        /// </summary>
        /// <returns></returns>
        public int GetEventsCount()
        {
            var element = _htmlDocument.DocumentNode
                .SelectNodes(EventsCountXPath)
                .FirstOrDefault();

            return element.SelectNodes(ArticleNode).Count;
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
                    .Where(x => x.Name == ChildHrefNode)
                    .ToList();

                return string.Join(ChildHrefSeperatorNode, childs.Select(x => x.InnerHtml).ToList());
            }

            return string.Empty;
        }

        /// <summary>
        /// Get text value
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public string GetValue(string xpath)
        {
            return _htmlDocument.DocumentNode
                .SelectNodes(xpath)
                ?.FirstOrDefault()
                ?.InnerText.Trim();
        }

        /// <summary>
        /// Get href value of link
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public string GetHrefValue(string xpath)
        {
            return _htmlDocument.DocumentNode
                .SelectNodes(xpath)
                ?.FirstOrDefault()
                .Attributes[HrefNode]
                ?.Value;
        }

        /// <summary>
        /// Get image path
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public string GetImage(string xpath)
        {
            return _htmlDocument.DocumentNode
                .SelectNodes(xpath)
                ?.FirstOrDefault()
                .Attributes[ImageNode]
                ?.Value;
        }
    }
}
