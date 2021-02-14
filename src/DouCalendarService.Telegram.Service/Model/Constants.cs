namespace DouCalendarService.Telegram.Service.Model
{
    public static class Constants
    {
        public static class Localization
        {
            public static readonly string UaCultureName = "uk-UA";

            public static readonly string StartKey = "Start";
            public static readonly string AboutKey = "About";
            public static readonly string HelpKey = "Help";
            public static readonly string VersionKey = "Version";

            public static readonly string LocationTextKey = "LocationText";
            public static readonly string TopicTextKey = "TopicText";
            public static readonly string DateTextKey = "DateText";
            public static readonly string AddEventToGoogleCalendarTextKey = "GoogleCalendar";

            public static readonly string NotFoundEventErrorMessageKey = "NotFoundEventErrorMessage";

            public static readonly string Start = "Привіт! Даний бот для отримання інформації про dou календар подій. Обери позицію з меню пошуку";
            public static readonly string About = "Даний бот створений для отримання сповіщення про різні події у ІТ спільності";
            public static readonly string Help = "Для отримання підтримки або повідомлення про помилку - напишіть мені на почту - ";
            public static readonly string Version = "Версія боту: v*1.0.0.0*";
            public static readonly string AddEventToGoogleCalendar = 
                "Для того, щоб додати івент до календарю - відправ мені ІД подіїї або лінку по подію";

            public static readonly string LocationText = "Введіть назву локації по якій хочете дізнатись події";
            public static readonly string TopicText = "Введіть назву теми по якій хочете дізнатись події";
            public static readonly string DateText = "Введіть дату у форматі *DD-MM-YYYY* по якому хочете дізнатись події";

            public static readonly string NotFoundEventErrorMessage = "За даною подіює *{0}* нічого не знайдено!";
        }
    }
}
