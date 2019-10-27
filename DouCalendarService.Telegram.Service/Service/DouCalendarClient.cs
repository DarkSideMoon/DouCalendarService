using DouCalendarService.Telegram.Service.Configuration;
using DouCalendarService.Telegram.Service.Model;
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
        private static readonly string EventByDateEndpoint = "/event/day/{0}";
        private static readonly string EventByLocationEndpoint = "/event/city/{0}";
        private static readonly string EventByTopicEndpoint = "/event/topic/{0}";

        private readonly HttpClient _httpClient;
        private readonly DouCalendarMicroserviceConfig _config;

        public DouCalendarClient(HttpClient httpClient, DouCalendarMicroserviceConfig config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<IEnumerable<ShortEvent>> GetEventsByDateAsync(string date)
        {
            var endpoint = string.Format(EventByDateEndpoint, date);
            return await GetDouCalendarDataAsync<IEnumerable<ShortEvent>>(endpoint);
        }

        public async Task<IEnumerable<ShortEvent>> GetEventsByLocationAsync(string location)
        {
            var endpoint = string.Format(EventByLocationEndpoint, location);
            return await GetDouCalendarDataAsync<IEnumerable<ShortEvent>>(endpoint);
        }

        public async Task<IEnumerable<ShortEvent>> GetEventsByTopicAsync(string topic)
        {
            var endpoint = string.Format(EventByTopicEndpoint, topic);
            return await GetDouCalendarDataAsync<IEnumerable<ShortEvent>>(endpoint);
        }

        public async Task<IEnumerable<string>> GetLocationTypesAsync()
        {
            return await GetDouCalendarDataAsync<IEnumerable<string>>(LocationTypeEndpoint);
        }

        public async Task<IEnumerable<string>> GetTopicTypesAsync()
        {
            return await GetDouCalendarDataAsync<IEnumerable<string>>(LocationTopicEndpoint);
        }

        private async Task<T> GetDouCalendarDataAsync<T>(string endpoint)
        {
            var requestUri = new Uri(string.Concat(_config.MicroserviceUri, endpoint));

            var response = await _httpClient.GetAsync(requestUri);
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
