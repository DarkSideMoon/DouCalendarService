using DouCalendarService.Telegram.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DouCalendarService.Telegram.Service.MessageBuilder
{
    public interface IDouMessageBuilder
    {
        IDouMessageBuilder AddCaption(string caption);

        IDouMessageBuilder AddLink(string link);

        IDouMessageBuilder AddMainText(string text);

        IDouMessageBuilder AddPlace(string place);

        IDouMessageBuilder AddPrice(string price);

        IDouMessageBuilder AddTime(string time);

        IDouMessageBuilder NewLine();

        string Build();

        string BuildShortEventMessage(ShortEvent shortEvent);

        string BuildShortEventMessage(IEnumerable<ShortEvent> shortEvents);
    }
}
