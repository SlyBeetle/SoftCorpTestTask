using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.ForecastFrame.PressureExtremumsParsers
{
    internal class MinPressuresParser : PressureExtremumsParser
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> minPressures = GetMinPressures(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Pressure.Min = minPressures[i];
            }
        }

        private IList<int> GetMinPressures(HtmlNode frame) => GetPressures(frame, "mint");
    }
}
