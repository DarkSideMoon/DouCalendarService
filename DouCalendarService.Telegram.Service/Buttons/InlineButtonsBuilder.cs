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
                        CallbackData = "Topic"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "📫 Пошта",
                        CallbackData = "Email"
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
