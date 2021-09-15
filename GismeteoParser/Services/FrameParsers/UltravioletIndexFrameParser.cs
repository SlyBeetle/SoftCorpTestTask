using System.Collections.Generic;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoCore.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.FrameParsers
{
    internal class UltravioletIndexFrameParser : FrameParser
    {
        public UltravioletIndexFrameParser(ICollection<IValuesParser<WeatherForecast>> valuesParsers) : base(valuesParsers)
        {
        }

        public override void Parse(HtmlDocument page, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetFrameByIndexNumber(page, 10);

            ExecuteValuesParsers(weatherForecastForTenDays);
        }
    }
}
