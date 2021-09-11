using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.WindFrame.WindVelocitiesParsers
{
    internal class DailyAverageWindVelocitiesParser : WindVelocitiesParser
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> dailyAverageWindVelocities = GetDailyAverageTemperatures(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Wind.DailyAverageVelocity = dailyAverageWindVelocities[i];
            }
        }

        private IList<int> GetDailyAverageTemperatures(HtmlNode frame) => GetWindVelocities(frame, "widget__row widget__row_table widget__row_wind");
    }
}
