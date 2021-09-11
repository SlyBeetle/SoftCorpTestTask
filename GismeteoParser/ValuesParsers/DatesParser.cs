using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.ValuesParsers
{
    internal class DatesParser : IValuesParser<WeatherForecast>
    {
        public void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<string> dates = GetDates(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Date = dates[i];
            }
        }

        private IList<string> GetDates(HtmlNode frame) =>
            frame.SelectNodes(".//div[@class=\"widget__row widget__row_date\"]//span").Select(node => node.InnerText.Trim()).ToArray();
    }
}
