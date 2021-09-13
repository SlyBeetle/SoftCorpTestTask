using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.ForecastFrame.TemperatureExtremumsParsers
{
    internal class MaxTemperaturesParser : TemperatureExtremumsParser
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetValues(
                frame,
                weatherForecastForTenDays,
                GetMaxTemperatures,
                (weatherForecast, value) => weatherForecast.Temperature.Max = value);
        }

        private IList<int> GetMaxTemperatures(HtmlNode frame) => GetTemperatures(frame, "maxt");
    }
}
