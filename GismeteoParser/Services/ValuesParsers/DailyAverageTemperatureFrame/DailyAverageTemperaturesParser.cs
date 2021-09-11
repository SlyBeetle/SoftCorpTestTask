using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.DailyAverageTemperatureFrame
{
    internal class DailyAverageTemperaturesParser : IValuesParser<WeatherForecast>
    {
        public void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> dailyAverageTemperatures = GetDailyAverageTemperatures(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Temperature.DailyAverage = dailyAverageTemperatures[i];
            }
        }

        private IList<int> GetDailyAverageTemperatures(HtmlNode frame) =>
            frame.SelectNodes(".//span[@class=\"unit unit_temperature_c\"]").Select(node => int.Parse(node.InnerText.Trim())).ToArray();
    }
}
