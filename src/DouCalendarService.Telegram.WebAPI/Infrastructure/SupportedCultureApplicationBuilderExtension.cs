using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace DouCalendarService.Telegram.WebAPI.Infrastructure
{
    public static class SupportedCultureApplicationBuilderExtension
    {
        public static IApplicationBuilder AddSupportedCultures(this IApplicationBuilder app)
        {
            var supportedCultures = new[]
{
                new CultureInfo("uk-UA")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("uk-UA"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            return app;
        }
    }
}
