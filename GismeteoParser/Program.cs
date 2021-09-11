﻿using System;
using System.Collections.Generic;
using GismeteoParserConsoleApplication.Services.FrameParsers;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using GismeteoParserConsoleApplication.Services;
using GismeteoParserConsoleApplication.Services.ValuesParsers;
using GismeteoParserConsoleApplication.Services.ValuesParsers.TemperatureExtremumsParsers;
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
                        })
                });
            unityContainer.RegisterType<IHtmlDocumentProvider, Grabber>();
            return unityContainer;
        }
    }
}
