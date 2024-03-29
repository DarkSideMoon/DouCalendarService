﻿using DouCalendarService.Telegram.Service.Bot;
using Microsoft.AspNetCore.Mvc;
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
            => Ok();

        [HttpPost]
        public async Task Post([FromBody] Update update) 
            => await _botService.ExecuteMessageAsync(update);
    }
}
