using System.Collections.Generic;
using GismeteoCore.Models.WeatherForecastModels;
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
                    if (valuesNode.SelectSingleNode($"./div[{i + 1}]/div[@class=\"mint\"]") == null)
                    {
                        minPressures.Insert(i, weatherForecastForTenDays[i].Pressure.Max);
                    }
                }
            }

            SetValues(weatherForecastForTenDays, minPressures, (weatherForecast, value) => weatherForecast.Pressure.Min = value);
        }

        private IList<int> GetMinPressures(HtmlNode frame) => GetPressures(frame, "mint");
    }
}
