using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.PressureFrame.PressureExtremumsParsers
{
    // MaxPressuresParser must come before MinPressuresParser
    internal class MaxPressuresParser : PressureExtremumsParser
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetValues(
                frame,
                weatherForecastForTenDays,
                GetMaxPressures,
                (weatherForecast, value) => weatherForecast.Pressure.Max = value);
        }

        private IList<int> GetMaxPressures(HtmlNode frame) => GetPressures(frame, "maxt");
    }
}
