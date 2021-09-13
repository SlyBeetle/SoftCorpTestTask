using System.Collections.Generic;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.FrameParsers
{
    internal class ForecastFrameParser : FrameParser
    {
        public ForecastFrameParser(ICollection<IValuesParser<WeatherForecast>> valuesParsers) : base(valuesParsers)
        {
        }

        public override void Parse(HtmlDocument page, IList<WeatherForecast> weatherForecastForTenDays)
        {
            _frame = page.DocumentNode.SelectSingleNode("//div[@class=\"forecast_frame\"]");

            ExecuteValuesParsers(weatherForecastForTenDays);
        }
    }
}
