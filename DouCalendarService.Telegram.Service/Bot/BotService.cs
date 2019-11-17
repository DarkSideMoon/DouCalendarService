﻿using DouCalendarService.Telegram.Service.Buttons;
using DouCalendarService.Telegram.Service.MessageBuilder;
using DouCalendarService.Telegram.Service.Model;
using DouCalendarService.Telegram.Service.Service;
using Microsoft.Extensions.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DouCalendarService.Telegram.Service.Bot
{
    public class BotService : IBotService
    {
        private const string BotCommandSymbol = "/";

        private readonly TelegramBotClient _telegramBotClient;
        private readonly IInlineButtonsBuilder _inlineButtonsBuilder;
        private readonly IDouCalendarClient _douCalendarClient;
        private readonly IDouMessageBuilder _messageBuilder;
        private readonly DouCalendarSetting _douCalendarSetting;
        private readonly IStringLocalizer _localizer;

        public BotService(
            TelegramBotClient telegramBotClient,
            IInlineButtonsBuilder inlineButtonsBuilder,
            IDouCalendarClient douCalendarClient,
            IDouMessageBuilder messageBuilder,
            DouCalendarSetting douCalendarSetting,
            IStringLocalizer localizer)
        {
            _telegramBotClient = telegramBotClient;
            _inlineButtonsBuilder = inlineButtonsBuilder;
            _douCalendarClient = douCalendarClient;
            _messageBuilder = messageBuilder;
            _douCalendarSetting = douCalendarSetting;
            _localizer = localizer;
        }

        public async Task ExecuteMessageAsync(Update update)
        {
            var message = update.Message;
            if (message?.Type == MessageType.Text && message.Text.Contains(BotCommandSymbol))
            {
                await ExecuteMessageText(message);
                return;
            }

            if (update.Type == UpdateType.CallbackQuery)
            {
                await ExecuteCallbackQuery(update);
            }

            if (update.Type == UpdateType.Message)
            {
                await ExecuteUserMessageText(update);
            }
        }

        private async Task ExecuteMessageText(Message message)
        {
            switch (message.Text)
            {
                case "/start":
                    await _telegramBotClient
                        .SendTextMessageAsync(
                        message.Chat.Id,
                        _localizer[Constants.Localization.StartKey],
                        replyMarkup: _inlineButtonsBuilder.BuildMainMenu());
                    break;
                case "/about":
                    await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, _localizer[Constants.Localization.AboutKey]);
                    break;
                case "/version":
                    await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, _localizer[Constants.Localization.VersionKey]);
                    break;
                case "/help":
                    await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, _localizer[Constants.Localization.HelpKey]);
                    break;
                case "/topics":
                    var topics = _douCalendarSetting.Topics;
                    await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, string.Join("\r\n", topics));
                    break;
                case "/locations":
                    var locations = _douCalendarSetting.Locations;
                    await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, string.Join("\r\n", locations));
                    break;
                default:
                    break;
            }
        }

        private async Task ExecuteCallbackQuery(Update update)
        {
            var callbackQuery = update.CallbackQuery;

            switch (callbackQuery.Data)
            {
                case "EventByLocation":
                    await _telegramBotClient.SendTextMessageAsync(
                        callbackQuery.Message.Chat.Id, 
                        _localizer[Constants.Localization.LocationTextKey]);
                    break;
                case "EventByDate":
                    await _telegramBotClient.SendTextMessageAsync(
                        callbackQuery.Message.Chat.Id, 
                        _localizer[Constants.Localization.DateTextKey], 
                        ParseMode.Markdown);
                    break;
                case "EventByTopic":
                    await _telegramBotClient.SendTextMessageAsync(
                        callbackQuery.Message.Chat.Id,
                        _localizer[Constants.Localization.TopicTextKey]);
                    break;
                default:
                    break;
            }

            await AnswerCallback(callbackQuery);
        }

        private async Task ExecuteUserMessageText(Update update)
        {
            var userMassage = update.Message;
            var userText = userMassage.Text;
            var chatId = userMassage.Chat.Id;

            var isMessageDateTime = DateTime.TryParse(userText, out var eventDateTime);
            if(isMessageDateTime)
            {
                await ExecuteEventByDay(chatId, eventDateTime);
            }

            var isMessageTopic = _douCalendarSetting.Topics.Any(x => x.ToLower() == userText.ToLower());
            if(isMessageTopic)
            {
                await ExecuteEventByTopic(chatId, userText);
            }

            var isMessageLocation = _douCalendarSetting.Locations.Any(x => x.ToLower() == userText.ToLower());
            if(isMessageLocation)
            {
                await ExecuteEventByLocation(chatId, userText);
            }

            await _telegramBotClient
                .SendTextMessageAsync(
                chatId, 
                string.Format(_localizer[Constants.Localization.NotFoundEventErrorMessageKey], userText), 
                ParseMode.Markdown);
        }

        private async Task ExecuteEventByLocation(long chatId, string userText)
        {
            var eventByLocation = await _douCalendarClient.GetEventsByLocationAsync(userText);
            var eventByLocationText = _messageBuilder.BuildShortEventMessage(eventByLocation);

            await _telegramBotClient.SendTextMessageAsync(chatId, eventByLocationText, ParseMode.Markdown);
        }

        private async Task ExecuteEventByTopic(long chatId, string userText)
        {
            var eventByTopc = await _douCalendarClient.GetEventsByTopicAsync(userText);
            var eventByTopicText = _messageBuilder.BuildShortEventMessage(eventByTopc);

            await _telegramBotClient.SendTextMessageAsync(chatId, eventByTopicText, ParseMode.Markdown);
        }

        private async Task ExecuteEventByDay(long chatId, DateTime eventDateTime)
        {
            var eventBydate = await _douCalendarClient.GetEventsByDateAsync(eventDateTime.ToShortDateString());
            var eventBydateText = _messageBuilder.BuildShortEventMessage(eventBydate);

            await _telegramBotClient.SendTextMessageAsync(chatId, eventBydateText, ParseMode.Markdown);
        }

        private async Task AnswerCallback(CallbackQuery callbackQuery)
        {
            await _telegramBotClient.AnswerCallbackQueryAsync(callbackQuery.Id);
        }
    }
}
