using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.ForecastFrame.TemperatureExtremumsParsers
{
    internal abstract class TemperatureExtremumsParser : IValuesParser<WeatherForecast>
    {
        public abstract void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays);

        protected IList<int> GetTemperatures(HtmlNode frame, string extremumType) =>
            frame.SelectNodes($".//div[@class=\"values\"]//div[@class=\"{extremumType}\"]/span[@class=\"unit unit_temperature_c\"]")
            .Select(node => int.Parse(node.InnerText.Replace("−", "-")))
            .ToArray();
    }
}
