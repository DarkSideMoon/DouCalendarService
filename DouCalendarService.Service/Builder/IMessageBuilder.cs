using System.Collections.Generic;

namespace DouCalendarService.Service.Builder
{
    public interface IMessageBuilder
    {
        IMessageBuilder AddCaption(string caption);

        IMessageBuilder AddLink(string link);

        IMessageBuilder AddTags(IEnumerable<string> values);

        IMessageBuilder AddMainText(string text);

        IMessageBuilder AddImage(string imageLink);

        IMessageBuilder AddPlace(string place);

        IMessageBuilder AddPrice(string price);

        IMessageBuilder AddTime(string time);

        IMessageBuilder NewLine();

        string Build();
    }
}
