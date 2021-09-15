using System.Collections.Generic;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoCore.Models.WeatherForecastModels;
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
            SetFrameByIndexNumber(page, 9);

            ExecuteValuesParsers(weatherForecastForTenDays);
        }
    }
}
