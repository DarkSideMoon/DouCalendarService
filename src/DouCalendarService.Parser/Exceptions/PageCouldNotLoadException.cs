using System;

namespace DouCalendarService.Parser.Exceptions
{
    public class PageCouldNotLoadException : Exception
    {
        public PageCouldNotLoadException(string message)
            : base(message)
        {
        }
    }
}
