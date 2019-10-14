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
        private const string TimeRangeRegex = @"^((?:[01]\d:[0-5][0-9]|2[0-3]:[0-5][0-9])(?:\s?)-(?:\s?)(?:[01]\d:[0-5][0-9]|2[0-3]:[0-5][0-9])(?:\s?,\s?)?)+$";

        private const char SmallDash = '-';
        private const char LargeDash = '—';
        private const char Space = ' ';

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
                { 9, new[] { "september", "вересня", "сентября" } },
                { 10, new[] { "october", "жовтня" } },
                { 11, new[] { "november", "листопада" } },
                { 12, new[] { "decemer", "грудня" } }
            };

        public DouDateTimeRange Parse(string date, string time)
        {
            var processedTime = ReplaceLargeDashOnSmallAndSpaces(time);

            var douDateArray = date.Split(Space);

            int.TryParse(douDateArray[0], out var douDate);
            var douMonthName = douDateArray[1];

            var numberOfMonth = GetNumberOfMonthByName(douMonthName);

            var timeMatch = Regex.Match(processedTime, TimeRegex);
            var timeRangeMatch = Regex.Match(processedTime, TimeRangeRegex);

            if (timeMatch.Success)
                return ParseDateTimeSame(timeMatch.Value, numberOfMonth, douDate);

            if (timeRangeMatch.Success)
                return ParseDateTimeRange(timeRangeMatch.Value, numberOfMonth, douDate);

            return new DouDateTimeRange
            {
                StartDate = default(DateTime),
                FinishDate = default(DateTime)
            };
        }

        private DouDateTimeRange ParseDateTimeSame(string value, int numberOfMonth, int douDate)
        {
            var parsedDateStart = ParseDateTime(value, numberOfMonth, douDate);
            return new DouDateTimeRange
            {
                StartDate = parsedDateStart,
                FinishDate = parsedDateStart
            };
        }

        private DouDateTimeRange ParseDateTimeRange(string value, int numberOfMonth, int douDate)
        {
            var timeArray = value.Split(SmallDash);
            var parsedDateStart = ParseDateTime(timeArray[0], numberOfMonth, douDate);
            var parsedDateFinish = ParseDateTime(timeArray[1], numberOfMonth, douDate);
            return new DouDateTimeRange
            {
                StartDate = parsedDateStart,
                FinishDate = parsedDateFinish
            };
        }

        private static DateTime ParseDateTime(string value, int numberOfMonth, int douDate)
        {
            var douTimeArray = value.Split(':');

            int.TryParse(douTimeArray[0], out var hourTime);
            int.TryParse(douTimeArray[1], out var minuteTime);

            var parsedDate = 
                new DateTime(DateTime.Now.Year, numberOfMonth, douDate, hourTime, minuteTime, 0);

            return parsedDate;
        }

        private static string ReplaceLargeDashOnSmallAndSpaces(string time)
        {
            if (time.Contains(LargeDash))
                return time
                    .Replace(LargeDash, SmallDash)
                    .Replace(Space.ToString(), "");

            return time;
        }

        private static int GetNumberOfMonthByName(string name)
        {
            return MonthMapper
                .FirstOrDefault(x => x.Value.Contains(name))
                .Key;
        }
    }
}
