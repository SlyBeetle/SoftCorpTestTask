using System.Collections.Generic;
using GismeteoCore.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.UltravioletIndexFrame
{
    internal class UltravioletIndicesParser : ValuesParser<WeatherForecast>
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetValues(
                frame,
                weatherForecastForTenDays,
                GetUltravioletIndices,
                (weatherForecast, value) => weatherForecast.UltravioletIndex = value);
        }

        private IList<int?> GetUltravioletIndices(HtmlNode frame) =>
            GetNullableIntegers(frame, ".//div[@class=\"widget__row widget__row_table widget__row_uvb\"]/div[@class=\"widget__item\"]/div");
    }
}
