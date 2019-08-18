using DouCalendarService.Service.MessageBuilder;
using DouCalendarService.Service.Dou;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DouCalendarService.Service.DouBot
{
    public class DouBotService : IDouBotService
    {
        private readonly IDouService _douService;
        private readonly IMessageBuilder _messageBuilder;

        public DouBotService(IDouService douService, IMessageBuilder messageBuilder)
        {
            _douService = douService;
            _messageBuilder = messageBuilder;
        }

        ///// <summary>
        ///// Get all message events on page
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<string> GetMessageEvents()
        //{
        //    var events = new List<string>();
        //    foreach (var douEvent in _douService.GetShortEvents())
        //    {
        //        _messageBuilder.AddCaption(douEvent.Name);
        //        _messageBuilder.AddTime(douEvent.Date);
        //        _messageBuilder.AddPlace(douEvent.Place);
        //        _messageBuilder.AddPrice(douEvent.Price);

        //        _messageBuilder.NewLine();

        //        events.Add(_messageBuilder.Build());
        //    }
        //    return events;
        //}
    }
}
