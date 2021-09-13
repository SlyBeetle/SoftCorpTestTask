using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.DailyAverageTemperatureFrame
{
    internal class DailyAverageTemperaturesParser : ValuesParser<WeatherForecast>
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetValues(
                frame,
                weatherForecastForTenDays,
                GetDailyAverageTemperatures,
                (weatherForecast, integer) => weatherForecast.Temperature.DailyAverage = integer);
        }

        private IList<int> GetDailyAverageTemperatures(HtmlNode frame) =>
            GetIntegers(frame, ".//span[@class=\"unit unit_temperature_c\"]");
    }
}
