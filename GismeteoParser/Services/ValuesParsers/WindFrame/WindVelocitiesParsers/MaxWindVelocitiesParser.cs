using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.WindFrame.WindVelocitiesParsers
{
    internal class MaxWindVelocitiesParser : WindVelocitiesParser
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int?> maxWindVelocities = GetMaxWindVelocitiesParser(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].Wind.MaxVelocity = maxWindVelocities[i];
            }
        }

        private IList<int?> GetMaxWindVelocitiesParser(HtmlNode frame) => GetWindVelocities(frame, "widget__row widget__row_table widget__row_gust");
    }
}
