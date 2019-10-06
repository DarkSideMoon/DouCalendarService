using DouCalendarService.Telegram.Service.Bot;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace DouCalendarService.Telegram.WebAPI.Controllers
{
    [ApiController]
    [Route("api/bot")]
    [Produces("application/json")]
    public class BotController : BaseController
    {
        private readonly IBotService _botService;

        public BotController(IBotService botService)
        {
            _botService = botService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public async void Post([FromBody] Update update)
        {
            await _botService.ExecuteMessageAsync(update);
        }
    }
}
