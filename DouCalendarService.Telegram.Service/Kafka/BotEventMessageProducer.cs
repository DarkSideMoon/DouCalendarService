using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using DouCalendarService.Telegram.Service.Model;

namespace DouCalendarService.Telegram.Service.Kafka
{
    public class BotEventMessageProducer : IBotEventMessageProducer, IDisposable
    {
        private readonly IProducer<Null, string> _botEventMessageProducer;
        private readonly KafkaSettings _kafkaSettings;

        public BotEventMessageProducer(KafkaSettings kafkaSettings)
        {
            _kafkaSettings = kafkaSettings;

            _botEventMessageProducer = new ProducerBuilder<Null, string>(kafkaSettings.ProducerClient)
                .SetKeySerializer(Serializers.Null)
                .SetValueSerializer(Serializers.Utf8)
                .Build();
        }

        public async Task ProduceMessageAsync(string message)
        {
            await _botEventMessageProducer.ProduceAsync(_kafkaSettings.Topic, new Message<Null, string>
            {
                Key = null,
                Value = message
            });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _botEventMessageProducer?.Flush();
            _botEventMessageProducer?.Dispose();
        }
    }
}
