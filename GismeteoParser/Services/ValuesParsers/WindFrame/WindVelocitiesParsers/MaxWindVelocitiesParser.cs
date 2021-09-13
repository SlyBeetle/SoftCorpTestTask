using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.WindFrame.WindVelocitiesParsers
{
    internal class MaxWindVelocitiesParser : WindVelocitiesParser
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetValues(
                frame,
                weatherForecastForTenDays,
                GetMaxWindVelocities,
                (weatherForecast, value) => weatherForecast.Wind.MaxVelocity = value);
        }

        private IList<int?> GetMaxWindVelocities(HtmlNode frame) => GetWindVelocities(frame, "widget__row widget__row_table widget__row_gust");
    }
}
