using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.WindFrame
{
    internal class DiractionsParser : IValuesParser<WeatherForecast>
    {
        public void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<string> directions = GetDirections(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Wind.Direction = directions[i];
            }
        }

        private IList<string> GetDirections(HtmlNode frame) =>
            frame.SelectNodes(".//div[@class=\"widget__row widget__row_table widget__row_wind\"]//div[@class=\"w_wind__direction gray\"]").Select(node => node.InnerText.Trim()).ToArray();
    }
}
