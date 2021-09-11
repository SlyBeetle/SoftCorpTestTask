using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers
{
    internal class DailyAverageWindVelocitiesParser : IValuesParser<WeatherForecast>
    {
        public void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> dailyAverageWindVelocities = GetDailyAverageTemperatures(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Wind.DailyAverageVelocity = dailyAverageWindVelocities[i];
            }
        }

        private IList<int> GetDailyAverageTemperatures(HtmlNode frame) =>
            frame.SelectNodes(".//div[@class=\"widget__row widget__row_table widget__row_wind\"]//span[@class=\"unit unit_wind_m_s\"]").Select(node => int.Parse(node.InnerText.Trim())).ToArray();
    }
}
