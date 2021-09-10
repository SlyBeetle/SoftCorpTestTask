using System;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using GismeteoParserConsoleApplication.Services;
using OpenQA.Selenium.PhantomJS;

namespace GismeteoParserConsoleApplication
{
    internal class Program
    {
        static void Main()
        {
            GismeteoParser gismeteoParser = new GismeteoParser(new Grabber(new PhantomJSDriver()), new IFrameParser<WeatherForecast>[] { new ForecastFrameParser() });
            var weatherForecasts = gismeteoParser.GetWeatherForecastForTenDays("https://www.gismeteo.by/weather-barnaul-4720/");
            Console.WriteLine();
            foreach (var weatherForecast in weatherForecasts)
            {
                Console.WriteLine(weatherForecast.Date);
                Console.WriteLine(weatherForecast.Temperature.Max);
                Console.WriteLine(weatherForecast.Temperature.Min);
                Console.WriteLine(weatherForecast.PrecipitationTotal);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
