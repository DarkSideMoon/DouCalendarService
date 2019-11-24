using Telegram.Bot.Types.ReplyMarkups;

namespace DouCalendarService.Telegram.Service.Buttons
{
    public class InlineButtonsBuilder : IInlineButtonsBuilder
    {
        public InlineKeyboardMarkup BuildMainMenu()
        {
            var keys = new[]
            {
                new[]
                {
                    new InlineKeyboardButton
                    {
                        Text = "📅 За датою",
                        CallbackData = "EventByDate"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "🌎 За локацією",
                        CallbackData = "EventByLocation"
                    }
                },
                new[]
                {
                    new InlineKeyboardButton
                    {
                        Text = "📗 За темою",
                        CallbackData = "EventByTopic"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "📆 Додати до календарю",
                        CallbackData = "AddEventToGoogleCalendar"
                    }
                },
                new[]
                {
                    new InlineKeyboardButton
                    {
                        Text = "⚙️ Про розробку",
                        CallbackData = "Develop"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "📊 Статус",
                        CallbackData = "Status"
                    }
                }
            };

            return new InlineKeyboardMarkup(keys);
        }
    }
}
