using System.Collections.Generic;
using GismeteoCore.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.RelativeHumidityFrame
{
    internal class RelativeHumidityParser : ValuesParser<WeatherForecast>
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetValues(
                frame,
                weatherForecastForTenDays,
                GetRelativeHumidity,
                (weatherForecast, value) => weatherForecast.RelativeHumidity = value);
        }

        private IList<int> GetRelativeHumidity(HtmlNode frame) =>
            GetIntegers(frame, ".//div[@class=\"widget__row widget__row_table widget__row_humidity\"]/div[@class=\"widget__item\"]/div");
    }
}
