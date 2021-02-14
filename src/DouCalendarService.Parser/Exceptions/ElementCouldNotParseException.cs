using System;

namespace DouCalendarService.Parser.Exceptions
{
    public class ElementCouldNotParseException : Exception
    {
        public ElementCouldNotParseException(string message)
            : base(message)
        {
        }
    }
}
