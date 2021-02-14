using Microsoft.AspNetCore.Builder;

namespace DouCalendarService.WebAPI.Infrastructure
{
    public static class SwaggerApplicationBuilderExtension
    {
        public static IApplicationBuilder AddSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", $"{DocumentationVariables.ServiceApiName} V1");
            });

            return app;
        }
    }
}
