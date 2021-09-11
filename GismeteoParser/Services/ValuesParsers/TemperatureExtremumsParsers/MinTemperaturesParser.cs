using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.TemperatureExtremumsParsers
{
    internal class MinTemperaturesParser : TemperatureExtremumsParser
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> minTemperatures = GetMinTemperatures(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Temperature.Min = minTemperatures[i];
            }
        }

        private IList<int> GetMinTemperatures(HtmlNode frame) => GetTemperatures(frame, "mint");
    }
}
