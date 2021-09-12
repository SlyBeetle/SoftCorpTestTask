using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.PressureFrame.PressureExtremumsParsers
{
    // MinPressuresParser must come after MaxPressuresParser
    internal class MinPressuresParser : PressureExtremumsParser
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> minPressures = GetMinPressures(frame);

            if (minPressures.Count < weatherForecastForTenDays.Count)
            {
                HtmlNode valuesNode = frame.SelectSingleNode(".//div[@class=\"values\"]");
                for (int i = 0; i < weatherForecastForTenDays.Count; i++)
                {
                    if (valuesNode.SelectSingleNode($"./div[{i}]/div[@class=\"mint\"]") == null)
                    {
                        minPressures.Insert(i, weatherForecastForTenDays[i].Pressure.Max);
                    }
                }
            }

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Pressure.Min = minPressures[i];
            }
        }

        private IList<int> GetMinPressures(HtmlNode frame) => GetPressures(frame, "mint");
    }
}
