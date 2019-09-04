using System;

namespace DouCalendarService.Contracts.Exceptions
{
    [Serializable]
    public class EventNotFoundException : Exception
    {
        public EventNotFoundException()
        {
        }

        public EventNotFoundException(string message)
            : base(message)
        {
        }

        public EventNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
