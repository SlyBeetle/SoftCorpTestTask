using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.PressureFrame.PressureExtremumsParsers
{
    internal class MaxPressuresParser : PressureExtremumsParser
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> maxPressures = GetMaxPressures(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Pressure.Max = maxPressures[i];
            }
        }

        private IList<int> GetMaxPressures(HtmlNode frame) => GetPressures(frame, "maxt");
    }
}
