using System;

namespace DouCalendarService.Service.Extensions
{
    public static class DateTimeExtensions
    {
        //private static readonly string OldDouDatePattern = "yyyyMMddTHHmmss";

        public static string ToDouDateTime(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy/MM/dd");
        }
    }
}
