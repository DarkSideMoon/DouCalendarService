using Newtonsoft.Json;

namespace DouCalendarService.Telegram.WebAPI.Configuration
{
    public class ServiceConfig
    {
        [JsonProperty("microserviceUri")]
        public string MicroserviceUri { get; set; }
    }
}
