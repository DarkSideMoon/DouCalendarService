using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DouCalendarService.WebAPI.HealthChecks
{
    public class DouSiteHealthCheck : IHealthCheck
    {
        private const string DouUrl = "https://dou.ua/calendar/";

        private readonly HttpClient _httpClient;

        public DouSiteHealthCheck(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            var result = await _httpClient.GetAsync(DouUrl, cancellationToken);
            return result.IsSuccessStatusCode ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
        }
    }
}
