using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.ForecastFrame.TemperatureExtremumsParsers
{
    internal class MinTemperaturesParser : TemperatureExtremumsParser
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int?> minTemperatures = GetMinTemperatures(frame).Cast<int?>().ToList();

            if (minTemperatures.Count < weatherForecastForTenDays.Count)
            {
                HtmlNode valuesNode = frame.SelectSingleNode(".//div[@class=\"values\"]");
                for (int i = 0; i < weatherForecastForTenDays.Count; i++)
                {
                    if (valuesNode.SelectSingleNode($"./div[{i + 1}]/div[@class=\"mint\"]") == null)
                    {
                        minTemperatures.Insert(i, null);
                    }
                }
            }

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Temperature.Min = minTemperatures[i];
            }
        }

        private IList<int> GetMinTemperatures(HtmlNode frame) => GetTemperatures(frame, "mint");
    }
}
