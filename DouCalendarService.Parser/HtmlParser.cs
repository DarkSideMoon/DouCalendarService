using HtmlAgilityPack;
using System.Linq;

namespace DouCalendarService.Parser
{
    public class HtmlParser
    {
        public string Test { get; set; }

        private string _url;

        public HtmlParser(string url)
        {
            _url = url;
        }


        public void Load(string xpath)
        {
            var web = new HtmlWeb();
            var doc = web.Load(_url);

            var res = doc.DocumentNode
                .SelectNodes(xpath)
                .FirstOrDefault()
                .InnerText.Trim();
        }
    }
}
