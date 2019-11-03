using System.Collections.Generic;

namespace DouCalendarService.Telegram.Service.Model
{
    public class DouCalendarSetting
    {
        public IEnumerable<string> Topics { get; }

        public IEnumerable<string> Locations { get; }

        public DouCalendarSetting(IEnumerable<string> topics, IEnumerable<string> locations)
        {
            Topics = topics;
            Locations = locations;
        }
    }
}
