using DouCalendarService.Parser.Exceptions;
using DouCalendarService.Parser.Model;
using HtmlAgilityPack;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DouCalendarService.Parser
{
    public class DouHtmlParser : IDouHtmlParser
    {
        private const string RegexNumberPattern = @"\d+";
        private const string EventsCountXPath = "/html/body/div[1]/div[{0}]/div/div[2]/div/div/div[1]";
        private const string AdvertiseTopHeader = "//*[@id=\"topinfo\"]";
        private const string ArticleNode = "article";
        private const string ChildHrefNode = "a";
        private const string ChildHrefSeperatorNode = ";";
        private const string HrefNode = "href";
        private const string ImageNode = "src";
        private const string DataUrlNode = "data-url";
        private const string DivNode = "div";

        private readonly HtmlDocument _htmlDocument;
        private readonly IDouDateTimeParser _douDateTimeParser;
        private readonly HttpClient _httpClient;

        public DouHtmlParser(HttpClient httpClient, IDouDateTimeParser douDateTimeParser)
        {
            _httpClient = httpClient;
            _douDateTimeParser = douDateTimeParser;
            _htmlDocument = new HtmlDocument();
        }

        /// <summary>
        /// Get text value
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public string GetValue(string xpath) => GetSafetyNode(xpath, nameof(GetValue)).InnerText.Trim();

        /// <summary>
        /// Get href value of link
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public string GetHrefValue(string xpath) => GetSafetyNode(xpath, nameof(GetHrefValue)).Attributes[HrefNode]?.Value;

        /// <summary>
        /// Get image path
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public string GetImage(string xpath) => GetSafetyNode(xpath, nameof(GetImage)).Attributes[ImageNode]?.Value;

        public string GetParsedUrl(string xpath) => GetSafetyNode(xpath, nameof(GetParsedUrl)).Attributes[DataUrlNode]?.Value;

        public DouDateTimeRange GetDouDateTime(string date, string time) => _douDateTimeParser.Parse(date, time);

        public bool IsHasAdvertiseHeader() => _htmlDocument.DocumentNode.SelectNodes(AdvertiseTopHeader)?.FirstOrDefault() != null;

        /// <summary>
        /// Load html page to HtmlDocument
        /// </summary>
        /// <returns></returns>
        public async Task LoadHtmlPage(string url)
        {
            using (var response = await _httpClient.GetAsync(url))
            {
                if (!response.IsSuccessStatusCode)
                    throw new PageCouldNotLoadException($"Could not load page. Status code: {response.StatusCode.ToString()}");

                var result = await response.Content.ReadAsStringAsync();
                _htmlDocument.LoadHtml(result);
            }
        }

        /// <summary>
        /// Get count of events on page
        /// </summary>
        /// <returns></returns>
        public int GetEventsCount(int indexOfDivElement)
        {
            var xpath = string.Format(EventsCountXPath, indexOfDivElement);

            var element = GetSafetyNode(xpath, nameof(GetEventsCount));
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

            if (html != null)
            {
                var childs = html.ChildNodes
                    .Where(x => x.Name == ChildHrefNode)
                    .ToList();

                return string.Join(ChildHrefSeperatorNode, childs.Select(x => x.InnerHtml).ToList());
            }

            return string.Empty;
        }

        /// <summary>
        /// Get id value path
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public string GetIdValue(string xpath)
        {
            var url = GetHrefValue(xpath);
            return url
                .Remove(url.Length - 1)
                .Split('/')
                .LastOrDefault();
        }

        public string GetCountOfEventVisitors(string xpath)
        {
            var element = _htmlDocument.DocumentNode
                .SelectNodes(xpath)
                ?.FirstOrDefault();

            return (element?.SelectNodes(DivNode)?.Count - 1).ToString();
        }

        public string GetCountOfShortEventVisitors(string xpath)
        {
            var element = _htmlDocument.DocumentNode
                .SelectNodes(xpath)
                ?.FirstOrDefault();

            if (element == null)
                return string.Empty;

            var countOfVisitorsMatch = new Regex(RegexNumberPattern).Match(element?.InnerText);
            return countOfVisitorsMatch.Success ? countOfVisitorsMatch.Value : string.Empty;
        }

        public string GetPrice(string xpath)
        {
            var element = _htmlDocument.DocumentNode
                .SelectNodes(xpath)
                ?.FirstOrDefault();

            if (element == null)
                return string.Empty;

            return element.InnerText.Trim();
        }

        private HtmlNode GetSafetyNode(string xpath, string nameOfElemnt)
        {
            var element = _htmlDocument.DocumentNode
                .SelectNodes(xpath)
                ?.FirstOrDefault();

            return element ?? throw new ElementCouldNotParseException($"Could not find element. Element {nameOfElemnt}. XPath {xpath}");
        }
    }
}
