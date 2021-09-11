using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.ForecastFrame.TemperatureExtremumsParsers
{
    internal class MaxTemperaturesParser : TemperatureExtremumsParser
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> maxTemperatures = GetMaxTemperatures(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Temperature.Max = maxTemperatures[i];
            }
        }

        private IList<int> GetMaxTemperatures(HtmlNode frame) => GetTemperatures(frame, "maxt");
    }
}
