using System.Collections.Generic;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.FrameParsers
{
    internal class RelativeHumidityFrameParser : FrameParser
    {
        public RelativeHumidityFrameParser(ICollection<IValuesParser<WeatherForecast>> valuesParsers) : base(valuesParsers)
        {
        }

        public override void Parse(HtmlDocument page, IList<WeatherForecast> weatherForecastForTenDays)
        {
            _frame = page.DocumentNode.SelectSingleNode(GetFrameXPathByIndexNumber(9));

            ExecuteValuesParsers(weatherForecastForTenDays);
        }
    }
}
