using System;

namespace DouCalendarService.Service.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDouDateTime(this DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMddTHHmmss");
        }
    }
}
