using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DouCalendarService.Parser.Model;

namespace DouCalendarService.Parser
{
    public class DouDateTimeParser : IDouDateTimeParser
    {
        private const string TimeRegex = "^(0[0-9]|1[0-9]|2[0-3]|[0-9]):[0-5][0-9]$";

        private static IReadOnlyDictionary<int, string[]> MonthMapper
            = new Dictionary<int, string[]>
            {
                { 1, new[] { "january", "січня" } },
                { 2, new[] { "february", "лютого" } },
                { 3, new[] { "march", "березня" } },
                { 4, new[] { "april", "квітня" } },
                { 5, new[] { "may", "травня" } },
                { 6, new[] { "june", "червня" } },
                { 7, new[] { "july", "липня" } },
                { 8, new[] { "august", "серпня" } },
                { 9, new[] { "september", "вересня" } },
                { 10, new[] { "october", "жовтня" } },
                { 11, new[] { "november", "листопада" } },
                { 12, new[] { "decemer", "грудня" } }
            };

        public DouDateTimeRange Parse(string date, string time)
        {
            DateTime parsedDateStart = default(DateTime);
            DateTime parsedDateFinish = default(DateTime);

            var douDateArray = date.Split(' ');

            int.TryParse(douDateArray[0], out var douDate);
            var douMonthName = douDateArray[1];

            var numberOfMonth = MonthMapper
                .FirstOrDefault(x => x.Value.Contains(douMonthName))
                .Key;

            var timeMatch = Regex.Match(time, TimeRegex);
            if(timeMatch.Success)
            {
                int.TryParse(timeMatch.Value.Split(':')[0], out var hourTime);
                parsedDateStart = new DateTime(DateTime.Now.Year, numberOfMonth, douDate, hourTime, 0, 0);
            }


            return new DouDateTimeRange
            {
                StartDate = parsedDateStart,
                FinishDate = DateTime.Now
            };
        }
    }
}
