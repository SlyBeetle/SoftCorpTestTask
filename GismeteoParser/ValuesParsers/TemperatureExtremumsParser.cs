using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.ValuesParsers
{
    internal class TemperatureExtremumsParser : IValuesParser<WeatherForecast>
    {
        public void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> maxTemperatures = GetMaxTemperatures(frame);
            IList<int> minTemperatures = GetMinTemperatures(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Temperature.Max = maxTemperatures[i];
                weatherForecastForTenDays[i].Temperature.Min = minTemperatures[i];
            }
        }

        private IList<int> GetMaxTemperatures(HtmlNode frame) => GetTemperatures(frame, "maxt");

        private IList<int> GetMinTemperatures(HtmlNode frame) => GetTemperatures(frame, "mint");

        private IList<int> GetTemperatures(HtmlNode frame, string extremumType) =>
            frame.SelectNodes($".//div[@class=\"values\"]//div[@class=\"{extremumType}\"]/span[@class=\"unit unit_temperature_c\"]").Select(node => int.Parse(node.InnerText)).ToArray();
    }
}
