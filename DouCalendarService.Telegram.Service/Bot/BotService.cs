﻿using System.Threading.Tasks;
using DouCalendarService.Telegram.Service.Buttons;
using DouCalendarService.Telegram.Service.Model;
using Microsoft.Extensions.Localization;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DouCalendarService.Telegram.Service.Bot
{
    public class BotService : IBotService
    {
        private const string About = "Даний бот створений для отримання сповіщення про різні події у ІТ спільності";
        private const string Help = "Для отримання підтримки або повідомлення про помилку - напишіть мені на почту - ";
        private const string Start = "Привіт! Даний бот для отримання інформації про dou календар подій. Обери позицію з меню пошуку";
        private const string Version = "Версія боту: v1.0.0.0";

        private const string ErrorStatus = "❌ Сервіс має критичну помилку";
        private const string WarningStatus = "️⚠️ Сервіс має певні збої у роботі";
        private const string HealthStatus = "✅ Сервіс працює коректно";

        private readonly TelegramBotClient _telegramBotClient;
        private readonly IInlineButtonsBuilder _inlineButtonsBuilder;
        private readonly IStringLocalizer<ResourceText> _localizer;

        public BotService(TelegramBotClient telegramBotClient,
            IInlineButtonsBuilder inlineButtonsBuilder,
            IStringLocalizer<ResourceText> localizer)
        {
            _telegramBotClient = telegramBotClient;
            _inlineButtonsBuilder = inlineButtonsBuilder;
            _localizer = localizer;
        }

        public async Task ExecuteMessageAsync(Update update)
        {
            var message = update.Message;
            if (message?.Type == MessageType.Text)
            {
                await ExecuteMessageText(message);
            }

            if (update.Type == UpdateType.CallbackQuery)
            {
                await ExecuteCallbackQuery(update);
            }
        }

        private async Task ExecuteMessageText(Message message)
        {
            switch (message.Text)
            {
                case "/start":
                    await _telegramBotClient
                        .SendTextMessageAsync(message.Chat.Id, Start, replyMarkup: _inlineButtonsBuilder.BuildMainMenu());
                    break;
                case "/about":
                    await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, About);
                    break;
                case "/version":
                    await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, Version);
                    break;
                case "/help":
                    await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, Help);
                    break;
            }
        }

        private async Task ExecuteCallbackQuery(Update update)
        {
            var callbackQuery = update.CallbackQuery;

            switch (callbackQuery.Data)
            {
                case "Status":
                    await _telegramBotClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, HealthStatus);
                    await AnswerCallback(callbackQuery);
                    break;
            }
        }

        private async Task AnswerCallback(CallbackQuery callbackQuery)
        {
            await _telegramBotClient.AnswerCallbackQueryAsync(callbackQuery.Id);
        }
    }
}