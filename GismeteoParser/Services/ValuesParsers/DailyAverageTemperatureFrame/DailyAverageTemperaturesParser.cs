using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.DailyAverageTemperatureFrame
{
    internal class DailyAverageTemperaturesParser : ValuesParser<WeatherForecast>
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> dailyAverageTemperatures = GetDailyAverageTemperatures(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Temperature.DailyAverage = dailyAverageTemperatures[i];
            }
        }

        private IList<int> GetDailyAverageTemperatures(HtmlNode frame) =>
            GetIntegers(frame, ".//span[@class=\"unit unit_temperature_c\"]");
    }
}
