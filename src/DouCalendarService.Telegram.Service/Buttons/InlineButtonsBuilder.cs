using Telegram.Bot.Types.ReplyMarkups;

namespace DouCalendarService.Telegram.Service.Buttons
{
    public class InlineButtonsBuilder : IInlineButtonsBuilder
    {
        public InlineKeyboardMarkup BuildMainMenu() => new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("📅 За датою", "EventByDate"),
                    InlineKeyboardButton.WithCallbackData("🌎 За локацією", "EventByLocation"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("📗 За темою", "EventByTopic"),
                    InlineKeyboardButton.WithCallbackData("📆 Додати до календарю", "AddEventToGoogleCalendar"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("⚙️ Про розробку", "Develop"),
                    InlineKeyboardButton.WithCallbackData("📊 Статус", "Status"),
                }
            });
    }
}
