using System.Collections.Generic;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.FrameParsers.Services
{
    internal class ForecastFrameParser : IFrameParser<WeatherForecast>
    {
        private readonly ICollection<IValuesParser<WeatherForecast>> _valuesParsers;
        private HtmlNode _forecastFrame;        

        public ForecastFrameParser(ICollection<IValuesParser<WeatherForecast>> valuesParsers)
        {
            _valuesParsers = valuesParsers;
        }

        public void Parse(HtmlDocument page, IList<WeatherForecast> weatherForecastForTenDays)
        {
            _forecastFrame = page.DocumentNode.SelectSingleNode("//div[@class=\"forecast_frame\"]");

            foreach (var valuesParser in _valuesParsers)
            {
                valuesParser.Parse(_forecastFrame, weatherForecastForTenDays);
            }
        }
    }
}
