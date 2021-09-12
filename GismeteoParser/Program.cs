using System;
using System.Collections.Generic;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using GismeteoParserConsoleApplication.Services;
using GismeteoParserConsoleApplication.Services.FrameParsers;
using GismeteoParserConsoleApplication.Services.ValuesParsers.DailyAverageTemperatureFrame;
using GismeteoParserConsoleApplication.Services.ValuesParsers.ForecastFrame;
using GismeteoParserConsoleApplication.Services.ValuesParsers.ForecastFrame.TemperatureExtremumsParsers;
using GismeteoParserConsoleApplication.Services.ValuesParsers.GeomagneticActivityFrame;
using GismeteoParserConsoleApplication.Services.ValuesParsers.PressureFrame.PressureExtremumsParsers;
using GismeteoParserConsoleApplication.Services.ValuesParsers.RelativeHumidityFrame;
using GismeteoParserConsoleApplication.Services.ValuesParsers.UltravioletIndexFrame;
using GismeteoParserConsoleApplication.Services.ValuesParsers.WindFrame;
using GismeteoParserConsoleApplication.Services.ValuesParsers.WindFrame.WindVelocitiesParsers;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using Unity;

namespace GismeteoParserConsoleApplication
{
    internal class Program
    {
        public static void Main()
        {
            IUnityContainer unityContainer = GetUnityContainer();

            GismeteoParser gismeteoParser = unityContainer.Resolve<GismeteoParser>();
            var weatherForecasts = gismeteoParser.GetWeatherForecastForTenDays("https://www.gismeteo.by/weather-barnaul-4720/");
            Console.WriteLine();
            foreach (var weatherForecast in weatherForecasts)
            {
                Console.WriteLine(weatherForecast.Date);
                Console.WriteLine(weatherForecast.Temperature.Max);
                Console.WriteLine(weatherForecast.Temperature.Min);
                Console.WriteLine(weatherForecast.PrecipitationTotal);
                Console.WriteLine(weatherForecast.Temperature.DailyAverage);
                Console.WriteLine(weatherForecast.Wind.DailyAverageVelocity);
                Console.WriteLine(weatherForecast.Wind.MaxVelocity);
                Console.WriteLine(weatherForecast.Wind.Direction);
                Console.WriteLine(weatherForecast.Pressure.Max);
                Console.WriteLine(weatherForecast.Pressure.Min);
                Console.WriteLine(weatherForecast.RelativeHumidity);
                Console.WriteLine(weatherForecast.UltravioletIndex);
                Console.WriteLine(weatherForecast.GeomagneticActivity);
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static IUnityContainer GetUnityContainer()
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IWebDriver, PhantomJSDriver>();
            unityContainer.RegisterInstance<ICollection<IFrameParser<WeatherForecast>>>(
                new IFrameParser<WeatherForecast>[] {
                    new ForecastFrameParser(
                        new IValuesParser<WeatherForecast>[]
                        {
                            new DatesParser(),
                            new PrecipitationTotalsParser(),
                            new MaxTemperaturesParser(),
                            new MinTemperaturesParser()
                        }),
                    new DailyAverageTemperatureFrameParser(
                        new IValuesParser<WeatherForecast>[]
                        {
                            new DailyAverageTemperaturesParser()
                        }),
                    new WindFrameParser(
                        new IValuesParser<WeatherForecast>[]
                        {
                            new DailyAverageWindVelocitiesParser(),
                            new MaxWindVelocitiesParser(),
                            new DiractionsParser()
                        }),
                    new PressureFrameParser(
                        new IValuesParser<WeatherForecast>[]
                        {
                            new MaxPressuresParser(),
                            new MinPressuresParser()
                        }),
                    new RelativeHumidityFrameParser(
                        new IValuesParser<WeatherForecast>[]
                        {
                            new RelativeHumidityParser()
                        }),
                    new UltravioletIndexFrameParser(
                        new IValuesParser<WeatherForecast>[]
                        {
                            new UltravioletIndicesParser()
                        }),
                    new GeomagneticActivityFrameParser(
                        new IValuesParser<WeatherForecast>[]
                        {
                            new GeomagneticActivityParser()
                        })
                });
            unityContainer.RegisterType<IHtmlDocumentProvider, Grabber>();
            return unityContainer;
        }
    }
}
