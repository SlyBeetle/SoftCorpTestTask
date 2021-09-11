using System.Collections.Generic;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.FrameParsers
{
    internal class WindFrameParser : IFrameParser<WeatherForecast>
    {
        private readonly ICollection<IValuesParser<WeatherForecast>> _valuesParsers;
        private HtmlNode _forecastFrame;

        public WindFrameParser(ICollection<IValuesParser<WeatherForecast>> valuesParsers)
        {
            _valuesParsers = valuesParsers;
        }

        public void Parse(HtmlDocument page, IList<WeatherForecast> weatherForecastForTenDays)
        {
            _forecastFrame = page.DocumentNode.SelectSingleNode("//div[@class=\"__frame_sm\"]/*[6]");

            foreach (var valuesParser in _valuesParsers)
            {
                valuesParser.Parse(_forecastFrame, weatherForecastForTenDays);
            }
        }
    }
}
