using System;
using System.Collections.Generic;
using GismeteoParserConsoleApplication.DAL;
using GismeteoParserConsoleApplication.DAL.Infrastructure;
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

            IGismeteoParser gismeteoParser = unityContainer.Resolve<IGismeteoParser>();            
            Console.WriteLine();
            using (IDataContext database = new GismeteoParserContext())
            {
                foreach (var cityAndWeatherForecastForTenDays in gismeteoParser.GetCitiesWithWeatherForecastForTenDays())
                {
                    Console.WriteLine(cityAndWeatherForecastForTenDays.Name + ": ");
                    database.Cities.Add(cityAndWeatherForecastForTenDays);
                    database.SaveChanges();
                    foreach (var weatherForecast in cityAndWeatherForecastForTenDays.WeatherForecasts)
                    {                        
                        Console.Write(weatherForecast.Date + "; ");
                        Console.Write(weatherForecast.Temperature.Max + "; ");
                        Console.Write(weatherForecast.Temperature.Min + "; ");
                        Console.Write(weatherForecast.PrecipitationTotal + "; ");
                        Console.Write(weatherForecast.Temperature.DailyAverage + "; ");
                        Console.Write(weatherForecast.Wind.DailyAverageVelocity + "; ");
                        Console.Write(weatherForecast.Wind.MaxVelocity + "; ");
                        Console.Write(weatherForecast.Wind.Direction + "; ");
                        Console.Write(weatherForecast.Pressure.Max + "; ");
                        Console.Write(weatherForecast.Pressure.Min + "; ");
                        Console.Write(weatherForecast.RelativeHumidity + "; ");
                        Console.Write(weatherForecast.UltravioletIndex + "; ");
                        Console.Write(weatherForecast.GeomagneticActivity + "; ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
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
                            new MaxPressuresParser(), // MaxPressuresParser must come before MinPressuresParser
                            new MinPressuresParser() // MinPressuresParser must come after MaxPressuresParser
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
            unityContainer.RegisterType<IGismeteoParser, GismeteoParser>();
            return unityContainer;
        }
    }
}
