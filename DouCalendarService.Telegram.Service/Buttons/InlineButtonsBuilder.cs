using Telegram.Bot.Types.ReplyMarkups;

namespace DouCalendarService.Telegram.Service.Buttons
{
    public class InlineButtonsBuilder : IInlineButtonsBuilder
    {
        public InlineKeyboardMarkup BuildMainMenu()
        {
            var keys = new[]
            {
                new InlineKeyboardButton[]
                {
                    new InlineKeyboardButton
                    {
                        Text = "📅 За датою",
                        CallbackData = "Date"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "🌎 За локацією",
                        CallbackData = "Location"
                    }
                },
                new InlineKeyboardButton[]
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
                new InlineKeyboardButton[]
                {
                    new InlineKeyboardButton
                    {
                        Text = "📫 За темою",
                        CallbackData = "Topic"
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
