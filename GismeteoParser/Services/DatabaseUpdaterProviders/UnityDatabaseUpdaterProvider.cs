using System.Collections.Generic;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
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

namespace GismeteoParserConsoleApplication.Services.DatabaseUpdaterProviders
{
    // Unfinished
    internal class UnityDatabaseUpdaterProvider
    {
        public IGismeteoParser GetGismeteoParser()
        {
            IUnityContainer unityContainer = GetUnityContainer();
            return unityContainer.Resolve<IGismeteoParser>();
        }

        private IUnityContainer GetUnityContainer()
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IWebDriver, PhantomJSDriver>();
            unityContainer.RegisterInstance<ICollection<IFrameParser<WeatherForecast>>>(
                new IFrameParser<WeatherForecast>[] {
                    new ForecastFrameParser(
                        new IValuesParser<WeatherForecast>[]
                        {
                            new DatesParser(),
                            new MaxTemperaturesParser(),
                            new MinTemperaturesParser(),
                            new PrecipitationTotalsParser()
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
