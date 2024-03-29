﻿using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace DouCalendarService.Telegram.Service.Bot
{
    public interface IBotService
    {
        Task ExecuteMessageAsync(Update update);
    }
}
