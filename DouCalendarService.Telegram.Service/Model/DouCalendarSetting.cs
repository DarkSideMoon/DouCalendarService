using System.Collections.Generic;

namespace DouCalendarService.Telegram.Service.Model
{
    public class DouCalendarSetting
    {
        public IEnumerable<string> Topics { get; }

        public IEnumerable<string> Locations { get; }

        public bool IsKafkaEventMessageProduce { get; }

        public DouCalendarSetting(IEnumerable<string> topics, IEnumerable<string> locations, bool isKafkaEventMessageProduce)
        {
            Topics = topics;
            Locations = locations;
            IsKafkaEventMessageProduce = isKafkaEventMessageProduce;
        }
    }
}
