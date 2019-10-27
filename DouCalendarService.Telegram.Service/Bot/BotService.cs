using DouCalendarService.Telegram.Service.Buttons;
using DouCalendarService.Telegram.Service.MessageBuilder;
using DouCalendarService.Telegram.Service.Service;
using System;
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

        public BotService(
            TelegramBotClient telegramBotClient,
            IInlineButtonsBuilder inlineButtonsBuilder,
            IDouCalendarClient douCalendarClient,
            IDouMessageBuilder messageBuilder)
        {
            _telegramBotClient = telegramBotClient;
            _inlineButtonsBuilder = inlineButtonsBuilder;
            _douCalendarClient = douCalendarClient;
            _messageBuilder = messageBuilder;
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
                    var topics = await _douCalendarClient.GetTopicTypesAsync();
                    await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, string.Join("\r\n", topics));
                    break;
                case "/locations":
                    var locations = await _douCalendarClient.GetLocationTypesAsync();
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

            var isMessageDateTime = DateTime.TryParse(userMassage.Text, out var eventDateTime);
            if(isMessageDateTime)
            {
                var result = await _douCalendarClient
                    .GetEventsByDateAsync(eventDateTime.ToShortDateString());

                var text = _messageBuilder.BuildShortEventMessage(result);

                await _telegramBotClient.SendTextMessageAsync(userMassage.Chat.Id, text, ParseMode.Markdown);
            }
        }

        private async Task AnswerCallback(CallbackQuery callbackQuery)
        {
            await _telegramBotClient.AnswerCallbackQueryAsync(callbackQuery.Id);
        }
    }
}
