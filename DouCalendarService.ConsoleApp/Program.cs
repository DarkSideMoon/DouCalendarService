using DouCalendarService.Model.Attributes;
using DouCalendarService.Model.Events;
using DouCalendarService.Parser.Dou;
using System;
using System.Collections.Generic;

namespace DouCalendarService.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var url = "https://dou.ua/calendar/";
            var parser = new DouHtmlParser(url);
            parser.Load();

            var shortEvents = new List<ShortEvent>();

            var eventsCount = parser.GetEventsCount();
            for (int i = 1; i <= eventsCount; i++)
            {
                var shortEvent = new ShortEvent()
                {
                    Name = parser.GetValue(string.Format(AttributeHelper.GetValue<ShortEvent>(x => x.Name), i))
                };

                shortEvents.Add(shortEvent);
            }


            Console.ReadLine();
        }
    }
}
