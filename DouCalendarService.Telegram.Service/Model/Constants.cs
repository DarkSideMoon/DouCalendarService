namespace DouCalendarService.Telegram.Service.Model
{
    public static class Constants
    {
        public static class Localization
        {
            public const string UaCultureName = "uk-UA";

            public const string StartKey = "Start";
            public const string AboutKey = "About";
            public const string HelpKey = "Help";
            public const string VersionKey = "Version";

            public const string LocationTextKey = "LocationText";
            public const string TopicTextKey = "TopicText";
            public const string DateTextKey = "DateText";

            public const string NotFoundEventErrorMessageKey = "NotFoundEventErrorMessage";

            public const string Start = "Привіт! Даний бот для отримання інформації про dou календар подій. Обери позицію з меню пошуку";
            public const string About = "Даний бот створений для отримання сповіщення про різні події у ІТ спільності";
            public const string Help = "Для отримання підтримки або повідомлення про помилку - напишіть мені на почту - ";
            public const string Version = "Версія боту: v*1.0.0.0*";

            public const string LocationText = "Введіть назву локації по якій хочете дізнатись події";
            public const string TopicText = "Введіть назву теми по якій хочете дізнатись події";
            public const string DateText = "Введіть дату у форматі *DD-MM-YYYY* по якому хочете дізнатись події";

            public const string NotFoundEventErrorMessage = "За даною подіює *{0}* нічого не знайдено!";
        }
    }
}
