using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DouCalendarService.WebAPI.Controllers
{
    public class BaseController : Controller
    {
        private static readonly ILogger Logger = Log.ForContext<BaseController>();

        protected void LogRequestInformation(string[] parameters)
        {
            Logger.Information("Log request: {@parameters}", parameters);
        }

        protected void LogResponseInformation(object response)
        {
            Logger.Information("Log response: {@parameter}", response);
        }
    }
}
