using Confluent.Kafka;

namespace DouCalendarService.Telegram.Service.Model
{
    public class KafkaSettings
    {
        public KafkaSettings(ProducerConfig producerClient, string topic)
        {
            ProducerClient = producerClient;
            Topic = topic;
        }

        public ProducerConfig ProducerClient { get; }

        public string Topic { get; }
    }
}
