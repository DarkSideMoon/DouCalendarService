using DouCalendarService.Parser;
using DouCalendarService.Service.Dou;
using System;
using System.Threading.Tasks;

namespace DouCalendarService.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var requestUrl = "https://dou.ua/calendar/?switch_lang=uk";
            var parser = new DouHtmlParser();

            var douService = new DouService(parser);
            //Task.WaitAll(douService.InitializeAsync(requestUrl));

            //var res = douService.GetShortEvents();
            //var message = douService.GetMessageEvent();

            Console.ReadLine();
        }
    }
}
