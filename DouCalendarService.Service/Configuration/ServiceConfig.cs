using Newtonsoft.Json;

namespace DouCalendarService.Service.Configuration
{
    [JsonObject("service")]
    public class ServiceConfig
    {
        [JsonProperty("tokenConfig")]
        public TokenConfig TokenConfig { get; set; }

        [JsonProperty("telegramClientKey")]
        public string TelegramClientKey { get; set; }
    }
}
