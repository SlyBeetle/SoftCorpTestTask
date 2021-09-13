using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.WindFrame
{
    internal class DiractionsParser : ValuesParser<WeatherForecast>
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetValues(
                frame,
                weatherForecastForTenDays,
                GetDirections,
                (weatherForecast, value) => weatherForecast.Wind.Direction = value);
        }

        private IList<string> GetDirections(HtmlNode frame) =>
            frame.SelectNodes(".//div[@class=\"widget__row widget__row_table widget__row_wind\"]//div[@class=\"w_wind__direction gray\"]").Select(node => node.InnerText.Trim()).ToArray();
    }
}
