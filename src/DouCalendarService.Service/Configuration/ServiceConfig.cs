using Newtonsoft.Json;

namespace DouCalendarService.Service.Configuration
{
    [JsonObject("service")]
    public class ServiceConfig
    {
        [JsonProperty("tokenConfig")]
        public TokenConfig TokenConfig { get; set; }
    }
}
