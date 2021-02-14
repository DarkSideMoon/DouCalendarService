using System;
using System.Collections.Generic;
using System.Text;
using DouCalendarService.Telegram.Service.Model;

namespace DouCalendarService.Telegram.Service.MessageBuilder
{
    public class DouMessageBuilder : IDouMessageBuilder
    {
        private static readonly string BoldMessage = "*{0}*";
        private static readonly string ItalicMessage = "_{0}_";
        private static readonly string MonospaceMessage = "`{0}`";
        private static readonly string ParenthesesMessage = " ({0})";

        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public IDouMessageBuilder AddCaption(string caption)
        {
            _stringBuilder.Append(string.Format(BoldMessage, caption));
            return this;
        }

        public IDouMessageBuilder AddLink(string link)
        {
            _stringBuilder.Append(link);
            NewLine();
            return this;
        }

        public IDouMessageBuilder AddMainText(string text)
        {
            _stringBuilder.Append(text);
            NewLine();
            return this;
        }

        public IDouMessageBuilder AddPlace(string place)
        {
            _stringBuilder.Append(string.Format(ItalicMessage, place));
            NewLine();
            return this;
        }

        public IDouMessageBuilder AddPrice(string price)
        {
            _stringBuilder.Append(string.Format(ItalicMessage, price));
            NewLine();
            return this;
        }

        public IDouMessageBuilder AddTime(string time)
        {
            _stringBuilder.Append(string.Format(ParenthesesMessage, string.Format(MonospaceMessage, time)));
            NewLine();
            return this;
        }

        public IDouMessageBuilder NewLine()
        {
            _stringBuilder.Append("\n");
            return this;
        }

        public string Build()
        {
            return _stringBuilder.ToString();
        }

        public string BuildShortEventMessage(ShortEvent shortEvent)
        {
            var message = AddCaption(shortEvent.Name)
                .AddTime(shortEvent.Date)
                .AddPlace(shortEvent.Place)
                .AddPrice(shortEvent.Price)
                .AddMainText(shortEvent.Description)
                .AddLink(shortEvent.Url)
                .NewLine()
                .Build();

            _stringBuilder.Clear();
            return message;
        }

        public string BuildShortEventMessage(IEnumerable<ShortEvent> shortEvents)
        {
            var stringBuilder = new StringBuilder();

            foreach (var shortEvent in shortEvents)
                stringBuilder.Append(BuildShortEventMessage(shortEvent));

            return stringBuilder.ToString();
        }
    }
}
