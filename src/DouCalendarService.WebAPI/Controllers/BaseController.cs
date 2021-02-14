using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DouCalendarService.WebAPI.Controllers
{
    public class BaseController : Controller
    {
        private static readonly ILogger Logger = Log.ForContext<BaseController>();

        protected static void LogRequestInformation(string parameter)
        {
            Logger.Information("Log request: {@parameters}", parameter);
        }

        protected static void LogRequestInformation(string[] parameters)
        {
            Logger.Information("Log request: {@parameters}", parameters);
        }

        protected static void LogResponseInformation(object response)
        {
            Logger.Information("Log response: {@parameter}", response);
        }
    }
}
