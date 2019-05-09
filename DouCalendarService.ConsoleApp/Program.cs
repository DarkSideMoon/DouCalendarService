using DouCalendarService.Model.Attributes;
using DouCalendarService.Model.Events;
using DouCalendarService.Parser;
using System;

namespace DouCalendarService.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var shortEvent = new ShortEvent();
            var nameXPath = 
                AttributeHelper
                .GetValue<ShortEvent, XPathLocationAttribute>(prop => prop.Name, attr => attr.Location);

            string url = "https://dou.ua/calendar/";
            var parser = new HtmlParser(url);
            
            parser.Load(nameXPath);

            Console.ReadLine();
        }
    }
}
