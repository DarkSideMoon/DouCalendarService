namespace DouCalendarService.Telegram.Service.Configuration
{
    public class DouCalendarMicroserviceConfig
    {
        public string MicroserviceUri { get; }

        public DouCalendarMicroserviceConfig(string microserviceUri)
        {
            MicroserviceUri = microserviceUri;
        }
    }
}
