using DouCalendarService.Telegram.Service.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DouCalendarService.Telegram.Service.Service
{
    public class DouCalendarClient : IDouCalendarClient
    {
        private static readonly string LocationTypeEndpoint = "/types/location";
        private static readonly string LocationTopicEndpoint = "/types/topic";

        private readonly HttpClient _httpClient;
        private readonly DouCalendarMicroserviceConfig _config;

        public DouCalendarClient(HttpClient httpClient, DouCalendarMicroserviceConfig config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<IEnumerable<string>> GetLocationTypesAsync()
        {
            var requestUri = new Uri(string.Concat(_config.MicroserviceUri, LocationTypeEndpoint));

            var response = await _httpClient.GetAsync(requestUri);
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<string>>(result);
        }

        public async Task<IEnumerable<string>> GetTopicTypesAsync()
        {
            var requestUri = new Uri(string.Concat(_config.MicroserviceUri, LocationTopicEndpoint));

            var response = await _httpClient.GetAsync(requestUri);
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<string>>(result);
        }
    }
}
