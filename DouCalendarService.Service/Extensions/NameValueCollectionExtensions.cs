using System;
using System.Collections.Specialized;
using System.Linq;

namespace DouCalendarService.Service.Extensions
{
    public static class NameValueCollectionExtensions
    {
        public static string ToQueryString(this NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                         from value in nvc.GetValues(key)
                         select string.Format("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value)))
                         .ToArray();
            return "?" + string.Join("&", array);
        }
    }
}
