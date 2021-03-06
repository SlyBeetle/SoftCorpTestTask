using System.Collections.Generic;
using GismeteoCore.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.GeomagneticActivityFrame
{
    internal class GeomagneticActivityParser : ValuesParser<WeatherForecast>
    {
        public override void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            SetValues(
                frame,
                weatherForecastForTenDays,
                GetGeomagneticActivity,
                (weatherForecast, value) => weatherForecast.GeomagneticActivity = value);
        }

        private IList<int> GetGeomagneticActivity(HtmlNode frame) =>
            GetIntegers(frame, ".//div[@class=\"widget__row widget__row_table widget__row_gm\"]/div[@class=\"widget__item\"]/div");
    }
}
