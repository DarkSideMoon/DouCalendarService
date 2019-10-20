using Telegram.Bot.Types.ReplyMarkups;

namespace DouCalendarService.Telegram.Service.Buttons
{
    public interface IInlineButtonsBuilder
    {
        InlineKeyboardMarkup BuildMainMenu();

        InlineKeyboardMarkup BuilDateMenu();
    }
}
