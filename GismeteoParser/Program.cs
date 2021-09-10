using System;
using OpenQA.Selenium.PhantomJS;

namespace GismeteoParser
{
    internal class Program
    {
        static void Main()
        {
            GismeteoParser gismeteoParser = new GismeteoParser(new Grabber(new PhantomJSDriver()));
            var urlOfCities = gismeteoParser.GetUrlOfCities();
            Console.WriteLine();
            foreach (string url in urlOfCities)
            {
                Console.WriteLine(url);
            }
            Console.ReadKey();
        }
    }
}
