using System.Threading.Tasks;

namespace DouCalendarService.Telegram.Service.Kafka
{
    public interface IBotEventMessageProducer
    {
        Task ProduceMessageAsync(string message);
    }
}
