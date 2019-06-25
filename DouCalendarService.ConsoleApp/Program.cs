using DouCalendarService.Parser.Dou;
using DouCalendarService.Service;
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
            var parser = new DouHtmlParser(requestUrl);

            var douService = new DouService(parser);
            Task.WaitAll(douService.InitializeAsync());

            var res = douService.GetShortEvents();

            Console.ReadLine();
        }
    }
}
