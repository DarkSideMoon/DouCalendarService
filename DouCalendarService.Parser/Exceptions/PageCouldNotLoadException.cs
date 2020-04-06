using System;

namespace DouCalendarService.Parser.Exceptions
{
    [Serializable]
    public class PageCouldNotLoadException : Exception
    {
        public PageCouldNotLoadException()
        {
        }

        public PageCouldNotLoadException(string message)
            : base(message)
        {
        }

        public PageCouldNotLoadException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
