using Confluent.Kafka;

namespace DouCalendarService.Telegram.WebAPI.Configuration
{
    public class ProducerConfiguration
    {
        public ProducerConfig Client { get; set; }

        public string Topic { get; set; }
    }
}
