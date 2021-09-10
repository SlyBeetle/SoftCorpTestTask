using System.Collections.Generic;
using System.Linq;
using GismeteoParser.Models;
using HtmlAgilityPack;

namespace GismeteoParser
{
    internal class ForecastFrameParser : IFrameParser<WeatherForecast>
    {
        private HtmlNode _forecastFrame;

        public void Parse(HtmlDocument page, IList<WeatherForecast> weatherForecastForTenDays)
        {
            _forecastFrame = page.DocumentNode.SelectSingleNode("//div[@class=\"forecast_frame\"]");

            IList<string> dates = GetDates();
            IList<int> maxTemperatures = GetMaxTemperatures();
            IList<int> minTemperatures = GetMinTemperatures();
            IList<double> precipitationTotals = GetPrecipitationTotals();

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Date = dates[i];
                weatherForecastForTenDays[i].Temperature.Max = maxTemperatures[i];
                weatherForecastForTenDays[i].Temperature.Min = minTemperatures[i];
                weatherForecastForTenDays[i].PrecipitationTotal = precipitationTotals[i];
            }
        }

        private IList<string> GetDates() =>
            _forecastFrame.SelectNodes(".//div[@class=\"widget__row widget__row_date\"]//span").Select(node => node.InnerText.Trim()).ToArray();

        private IList<int> GetMaxTemperatures() => GetTemperatures("maxt");

        private IList<int> GetMinTemperatures() => GetTemperatures("mint");

        private IList<int> GetTemperatures(string extremumType) =>
            _forecastFrame.SelectNodes($".//div[@class=\"values\"]//div[@class=\"{extremumType}\"]/span[@class=\"unit unit_temperature_c\"]").Select(node => int.Parse(node.InnerText)).ToArray();

        private IList<double> GetPrecipitationTotals() =>
            _forecastFrame.SelectNodes(".//div[@class=\"widget__row widget__row_table widget__row_precipitation\"]//div[@class=\"w_prec__value\"]").Select(n => double.Parse(n.InnerText)).ToArray();
    }
}
