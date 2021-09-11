using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.ForecastFrame
{
    internal class PrecipitationTotalsParser : IValuesParser<WeatherForecast>
    {
        public void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<double> precipitationTotals = GetPrecipitationTotals(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].PrecipitationTotal = precipitationTotals[i];
            }
        }

        private IList<double> GetPrecipitationTotals(HtmlNode frame) =>
            frame.SelectNodes(".//div[@class=\"widget__row widget__row_table widget__row_precipitation\"]//div[@class=\"w_prec__value\"]").Select(n => double.Parse(n.InnerText)).ToArray();
    }
}
