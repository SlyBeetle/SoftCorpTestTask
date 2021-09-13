using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.RelativeHumidityFrame
{
    internal class RelativeHumidityParser : ValuesParser<WeatherForecast>
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> relativeHumidity = GetRelativeHumidity(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].RelativeHumidity = relativeHumidity[i];
            }
        }

        private IList<int> GetRelativeHumidity(HtmlNode frame) =>
            GetIntegers(frame, ".//div[@class=\"widget__row widget__row_table widget__row_humidity\"]/div[@class=\"widget__item\"]/div");
    }
}
