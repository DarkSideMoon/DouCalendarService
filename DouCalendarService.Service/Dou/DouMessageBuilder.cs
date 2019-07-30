using DouCalendarService.Service.Builder;
using System.Collections.Generic;
using System.Text;

namespace DouCalendarService.Service.Dou
{
    public class DouMessageBuilder : IMessageBuilder
    {
        private static readonly string BoldMessage = "**{0}**";
        private static readonly string ItalicMessage = "__{0}__";
        private static readonly string MonospaceMessage = "`{0}`";

        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public IMessageBuilder AddCaption(string caption)
        {
            _stringBuilder.Append(string.Format(BoldMessage, caption));
            return this;
        }

        public IMessageBuilder AddImage(string imageLink)
        {
            _stringBuilder.Append(imageLink);
            return this;
        }

        public IMessageBuilder AddLink(string link)
        {
            _stringBuilder.Append(link);
            return this;
        }

        public IMessageBuilder AddTags(IEnumerable<string> values)
        {
            _stringBuilder.Append(string.Join(" ", values));
            return this;
        }

        public IMessageBuilder AddMainText(string text)
        {
            _stringBuilder.Append(text);
            return this;
        }

        public IMessageBuilder AddPlace(string place)
        {
            _stringBuilder.Append(string.Format(BoldMessage, place));
            return this;
        }

        public IMessageBuilder AddPrice(string price)
        {
            _stringBuilder.Append(string.Format(BoldMessage, price));
            return this;
        }

        public IMessageBuilder AddTime(string time)
        {
            _stringBuilder.Append(string.Format(MonospaceMessage, time));
            return this;
        }

        public string Build()
        {
            return _stringBuilder.ToString();
        }
    }
}
