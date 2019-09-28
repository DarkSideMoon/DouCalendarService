using Newtonsoft.Json;

namespace DouCalendarService.Service.Configuration
{
    [JsonObject("tokenConfig")]
    public class TokenConfig
    {
        [JsonProperty("signSecretKey")]
        public string SignSecretKey { get; set; }

        [JsonProperty("encodingSecretKey")]
        public string EncodingSecretKey { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("audience")]
        public string Audience { get; set; }

        [JsonProperty("accessExpiration")]
        public int AccessExpiration { get; set; }
    }
}
