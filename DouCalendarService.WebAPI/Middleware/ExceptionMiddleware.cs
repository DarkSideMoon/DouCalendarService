using System;
using System.Threading.Tasks;
using DouCalendarService.Contracts.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DouCalendarService.WebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ExceptionMiddleware(RequestDelegate next, IHostingEnvironment hostingEnvironment)
        {
            _next = next;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, "Internal Server Error",
                    StatusCodes.Status500InternalServerError);
            }
        }

        protected Task HandleExceptionAsync(HttpContext context, Exception exception, string message, 
            int statusCode)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var errorResponse = CreateErrorResponse(context, message);
            var errorResponseJson = JsonConvert.SerializeObject(errorResponse, 
                new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            return context.Response.WriteAsync(errorResponseJson);
        }

        protected ErrorResponse CreateErrorResponse(HttpContext context, string message)
        {
            return new ErrorResponse(context.Response.StatusCode.ToString(), message);
        }
    }
}
