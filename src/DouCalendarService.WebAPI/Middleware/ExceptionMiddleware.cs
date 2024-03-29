﻿using System;
using System.Threading.Tasks;
using DouCalendarService.Contracts.Common;
using DouCalendarService.Contracts.Exceptions;
using DouCalendarService.Parser.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace DouCalendarService.WebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ElementCouldNotParseException ex)
            {
                await HandleExceptionAsync(httpContext, ex, ex.Message, StatusCodes.Status501NotImplemented).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is PageCouldNotLoadException || ex is EventNotFoundException)
            {
                await HandleExceptionAsync(httpContext, ex, ex.Message, StatusCodes.Status404NotFound).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, "Internal Server Error",
                    StatusCodes.Status500InternalServerError).ConfigureAwait(false);
            }
        }

        protected static Task HandleExceptionAsync(HttpContext context, Exception exception, string message, 
            int statusCode)
        {
            Log.Warning(exception, message);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var errorResponse = CreateErrorResponse(context, message);
            var errorResponseJson = JsonConvert.SerializeObject(errorResponse, 
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            return context.Response.WriteAsync(errorResponseJson);
        }

        protected static ErrorResponse CreateErrorResponse(HttpContext context, string message)
        {
            return new ErrorResponse(context.Response.StatusCode.ToString(), message);
        }
    }
}
