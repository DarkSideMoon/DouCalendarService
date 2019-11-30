using Newtonsoft.Json;

namespace DouCalendarService.Telegram.WebAPI.Configuration
{
    public class KafkaConfiguration
    {
        [JsonProperty("botEventProducer")]
        public ProducerConfiguration BotEventProducer { get; set; }
    }
}
