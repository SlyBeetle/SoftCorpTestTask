using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.ForecastFrame
{
    internal class PrecipitationTotalsParser : ValuesParser<WeatherForecast>
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetValues(
                frame,
                weatherForecastForTenDays,
                GetPrecipitationTotals,
                (weatherForecast, value) => weatherForecast.PrecipitationTotal = value);
        }

        private IList<double> GetPrecipitationTotals(HtmlNode frame) =>
            frame.SelectNodes(".//div[@class=\"widget__row widget__row_table widget__row_precipitation\"]//div[@class=\"w_prec__value\"]")
            .Select(node => double.Parse(node.InnerText))
            .ToArray();
    }
}
