using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.ForecastFrame
{
    internal class DatesParser : ValuesParser<WeatherForecast>
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetValues(
                frame,
                weatherForecastForTenDays,
                GetDates,
                (weatherForecast, value) => weatherForecast.Date = value);
        }

        private IList<string> GetDates(HtmlNode frame) =>
            GetStrings(frame, ".//div[@class=\"widget__row widget__row_date\"]//span");

    }
}
