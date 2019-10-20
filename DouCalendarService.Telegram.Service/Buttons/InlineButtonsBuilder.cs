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
                        CallbackData = "Date"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "🌎 За локацією",
                        CallbackData = "Location"
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

        public InlineKeyboardMarkup BuilDateMenu()
        {
            var keys = new[]
            {
                new[]
                {
                    new InlineKeyboardButton
                    {
                        Text = "📅 Сьогодні",
                        CallbackData = "Today"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "📅 Завтра",
                        CallbackData = "Tomorrow"
                    }
                },
                new[]
                {
                    new InlineKeyboardButton
                    {
                        Text = "📍 Вибраний день",
                        CallbackData = "Custom"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "🔙 Повернутись",
                        CallbackData = "Back"
                    }
                }
            };

            return new InlineKeyboardMarkup(keys);
        }
    }
}
