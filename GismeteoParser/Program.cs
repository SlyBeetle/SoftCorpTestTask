using System;
using GismeteoParser.Infrastructure;
using GismeteoParser.Models;
using OpenQA.Selenium.PhantomJS;

namespace GismeteoParser
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
