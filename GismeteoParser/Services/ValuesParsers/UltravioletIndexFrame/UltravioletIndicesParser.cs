using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.UltravioletIndexFrame
{
    internal class UltravioletIndicesParser : IValuesParser<WeatherForecast>
    {
        public void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> ultravioletIndices = GetUltravioletIndices(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].UltravioletIndex = ultravioletIndices[i];
            }
        }

        private IList<int> GetUltravioletIndices(HtmlNode frame) =>
            frame.SelectNodes(".//div[@class=\"widget__row widget__row_table widget__row_uvb\"]/div[@class=\"widget__item\"]/div").Select(node => int.Parse(node.InnerText.Trim())).ToArray();
    }
}
