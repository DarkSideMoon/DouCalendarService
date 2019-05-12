using HtmlAgilityPack;
using System.Linq;

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

        public virtual void Load()
        {
            var web = new HtmlWeb();
            _htmlDocument = web.Load(_url);
        }

        public virtual string GetValue(string xpath)
        {
            return _htmlDocument.DocumentNode
                .SelectNodes(xpath)
                .FirstOrDefault()
                .InnerText.Trim();
        }
    }
}
