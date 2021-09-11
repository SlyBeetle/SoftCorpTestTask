using System.Collections.Generic;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.FrameParsers
{
    internal class DailyAverageTemperatureFrameParser : FrameParser
    {
        public DailyAverageTemperatureFrameParser(ICollection<IValuesParser<WeatherForecast>> valuesParsers) : base(valuesParsers)
        {
        }

        public override void Parse(HtmlDocument page, IList<WeatherForecast> weatherForecastForTenDays)
        {
            _frame = page.DocumentNode.SelectSingleNode("//div[@class=\"__frame_sm\"]/*[5]");

            ExecuteValuesParsers(weatherForecastForTenDays);
        }
    }
}
