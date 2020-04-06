using System;

namespace DouCalendarService.Parser.Exceptions
{
    [Serializable]
    public class ElementCouldNotParseException : Exception
    {
        public ElementCouldNotParseException()
        {
        }

        public ElementCouldNotParseException(string message)
            : base(message)
        {
        }

        public ElementCouldNotParseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
