using DouCalendarService.Telegram.Service.Model;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DouCalendarService.Telegram.WebAPI.Localization
{
    public class BotStringLocalizer : IStringLocalizer
    {
        private readonly Dictionary<string, Dictionary<string, string>> resources;

        public LocalizedString this[string name, params object[] arguments] => throw new NotImplementedException();

        public LocalizedString this[string name]
        {
            get
            {
                var currentCulurute = CultureInfo.CurrentCulture;
                var currentCultureName = currentCulurute.Name;
                string textValue = string.Empty;

                if(resources.ContainsKey(currentCultureName))
                {
                    if (resources[currentCultureName].ContainsKey(name))
                    {
                        textValue = resources[currentCultureName][name];
                    }
                }

                return new LocalizedString(name, textValue);
            }
        }

        public BotStringLocalizer()
        {
            var uaDictionary = new Dictionary<string, string>
            {
                { Constants.Localization.StartKey, Constants.Localization.Start },
                { Constants.Localization.AboutKey, Constants.Localization.About },
                { Constants.Localization.HelpKey, Constants.Localization.Help },
                { Constants.Localization.VersionKey, Constants.Localization.Version },

                { Constants.Localization.LocationTextKey, Constants.Localization.LocationText },
                { Constants.Localization.TopicTextKey, Constants.Localization.TopicText },
                { Constants.Localization.DateTextKey, Constants.Localization.DateText },
                { Constants.Localization.AddEventToGoogleCalendarTextKey, Constants.Localization.AddEventToGoogleCalendar },

                { Constants.Localization.NotFoundEventErrorMessageKey, Constants.Localization.NotFoundEventErrorMessage }
            };

            resources = new Dictionary<string, Dictionary<string, string>>
            {
                { Constants.Localization.UaCultureName, uaDictionary }
            };
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return this;
        }
    }
}
