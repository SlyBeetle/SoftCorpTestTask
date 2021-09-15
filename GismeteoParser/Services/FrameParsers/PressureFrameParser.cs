using System.Collections.Generic;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoCore.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.FrameParsers
{
    internal class PressureFrameParser : FrameParser
    {
        public PressureFrameParser(ICollection<IValuesParser<WeatherForecast>> valuesParsers) : base(valuesParsers)
        {
        }

        public override void Parse(HtmlDocument page, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetFrameByIndexNumber(page, 8);

            ExecuteValuesParsers(weatherForecastForTenDays);
        }
    }
}
