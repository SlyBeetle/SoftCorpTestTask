using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.DailyAverageTemperatureFrame
{
    internal class RelativeHumidityParser : IValuesParser<WeatherForecast>
    {
        public void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> relativeHumidity = GetRelativeHumidity(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].RelativeHumidity = relativeHumidity[i];
            }
        }

        private IList<int> GetRelativeHumidity(HtmlNode frame) =>
            frame.SelectNodes(".//div[@class=\"widget__row widget__row_table widget__row_humidity\"]/div[@class=\"widget__item\"]/div").Select(node => int.Parse(node.InnerText.Trim())).ToArray();
    }
}
