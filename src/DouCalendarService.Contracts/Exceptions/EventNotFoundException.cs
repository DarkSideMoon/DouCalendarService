using System;

namespace DouCalendarService.Contracts.Exceptions
{
    public class EventNotFoundException : Exception
    {
        public EventNotFoundException(string message)
            : base(message)
        {
        }
    }
}
