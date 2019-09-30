using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DouCalendarService.Telegram.WebAPI.Controllers
{
    public class BaseController : Controller
    {
        private static readonly ILogger Logger = Log.ForContext<BaseController>();

        protected void LogRequestInformation(string parameter)
        {
            Logger.Information("Log request: {@parameters}", parameter);
        }

        protected void LogResponseInformation(object response)
        {
            Logger.Information("Log response: {@parameter}", response);
        }
    }
}
