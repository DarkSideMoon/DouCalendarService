using HtmlAgilityPack;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DouCalendarService.Parser
{
    public abstract class HtmlParser
    {
        public string Test { get; set; }

        protected string _url;

        protected HtmlDocument _htmlDocument;

        public HtmlParser(string url)
        {
            _url = url;
        }

        public virtual async Task Load()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_url))
                {
                    var result = await response.Content.ReadAsStringAsync();

                    _htmlDocument = new HtmlDocument();
                    _htmlDocument.LoadHtml(result);
                }
            }
        }

        public virtual string GetValue(string xpath)
        {
            return _htmlDocument.DocumentNode
                .SelectNodes(xpath)
                ?.FirstOrDefault()
                ?.InnerText.Trim();
        }

        public virtual string GetImage(string xpath)
        {
            return _htmlDocument.DocumentNode
                .SelectNodes(xpath)
                ?.FirstOrDefault()
                .Attributes["src"]
                ?.Value;
        }
    }
}
