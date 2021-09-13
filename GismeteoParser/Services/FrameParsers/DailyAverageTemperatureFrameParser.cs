using System.Collections.Generic;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
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
            SetFrameByIndexNumber(page, 5);

            ExecuteValuesParsers(weatherForecastForTenDays);
        }
    }
}
