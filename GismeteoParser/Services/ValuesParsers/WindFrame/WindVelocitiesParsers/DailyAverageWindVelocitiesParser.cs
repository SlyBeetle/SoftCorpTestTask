using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.WindFrame.WindVelocitiesParsers
{
    internal class DailyAverageWindVelocitiesParser : WindVelocitiesParser
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetValues(
                frame,
                weatherForecastForTenDays,
                GetDailyAverageWindVelocities,
                (weatherForecast, value) => weatherForecast.Wind.DailyAverageVelocity = value.Value);
        }

        private IList<int?> GetDailyAverageWindVelocities(HtmlNode frame) => GetWindVelocities(frame, "widget__row widget__row_table widget__row_wind");
    }
}
