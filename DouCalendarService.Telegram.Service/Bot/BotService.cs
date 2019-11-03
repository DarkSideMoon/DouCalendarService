using DouCalendarService.Telegram.Service.Buttons;
using DouCalendarService.Telegram.Service.MessageBuilder;
using DouCalendarService.Telegram.Service.Model;
using DouCalendarService.Telegram.Service.Service;
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
        private const string About = "Даний бот створений для отримання сповіщення про різні події у ІТ спільності";
        private const string Help = "Для отримання підтримки або повідомлення про помилку - напишіть мені на почту - ";
        private const string Start = "Привіт! Даний бот для отримання інформації про dou календар подій. Обери позицію з меню пошуку";
        private const string Version = "Версія боту: v1.0.0.0";

        private const string ErrorStatus = "❌ Сервіс має критичну помилку";
        private const string WarningStatus = "️⚠️ Сервіс має певні збої у роботі";
        private const string HealthStatus = "✅ Сервіс працює коректно";

        private const string LocationText = "Введіть назву локації по якій хочете дізнатись події";
        private const string TopicText = "Введіть назву теми по якій хочете дізнатись події";
        private const string DateText = "Введіть дату у форматі DD-MM-YYYY по якому хочете дізнатись події";

        private readonly TelegramBotClient _telegramBotClient;
        private readonly IInlineButtonsBuilder _inlineButtonsBuilder;
        private readonly IDouCalendarClient _douCalendarClient;
        private readonly IDouMessageBuilder _messageBuilder;
        private readonly DouCalendarSetting _douCalendarSetting;

        public BotService(
            TelegramBotClient telegramBotClient,
            IInlineButtonsBuilder inlineButtonsBuilder,
            IDouCalendarClient douCalendarClient,
            IDouMessageBuilder messageBuilder,
            DouCalendarSetting douCalendarSetting)
        {
            _telegramBotClient = telegramBotClient;
            _inlineButtonsBuilder = inlineButtonsBuilder;
            _douCalendarClient = douCalendarClient;
            _messageBuilder = messageBuilder;
            _douCalendarSetting = douCalendarSetting;
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
                case "Status":
                    await _telegramBotClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, HealthStatus);
                    break;
                case "EventByLocation":
                    await _telegramBotClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, LocationText);
                    break;
                case "EventByDate":
                    await _telegramBotClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, DateText);
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

            var isMessageDateTime = DateTime.TryParse(userText, out var eventDateTime);
            if(isMessageDateTime)
            {
                var eventBydate = await _douCalendarClient.GetEventsByDateAsync(eventDateTime.ToShortDateString());
                var eventBydateText = _messageBuilder.BuildShortEventMessage(eventBydate);

                await _telegramBotClient.SendTextMessageAsync(userMassage.Chat.Id, eventBydateText, ParseMode.Markdown);
            }

            var isMessageTopic = _douCalendarSetting.Topics.Any(x => x.ToLower() == userText.ToLower());
            if(isMessageTopic)
            {
                var eventByTopc = await _douCalendarClient.GetEventsByTopicAsync(userText);
                var eventByTopicText = _messageBuilder.BuildShortEventMessage(eventByTopc);

                await _telegramBotClient.SendTextMessageAsync(userMassage.Chat.Id, eventByTopicText, ParseMode.Markdown);
            }

            var isMessageLocation = _douCalendarSetting.Locations.Any(x => x.ToLower() == userText.ToLower());
            if(isMessageLocation)
            {
                var eventByLocation = await _douCalendarClient.GetEventsByLocationAsync(userText);
                var eventByLocationText = _messageBuilder.BuildShortEventMessage(eventByLocation);

                await _telegramBotClient.SendTextMessageAsync(userMassage.Chat.Id, eventByLocationText, ParseMode.Markdown);
            }

            // Write message could not find any data by user text
        }

        private async Task AnswerCallback(CallbackQuery callbackQuery)
        {
            await _telegramBotClient.AnswerCallbackQueryAsync(callbackQuery.Id);
        }
    }
}
