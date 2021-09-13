using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.GeomagneticActivityFrame
{
    internal class GeomagneticActivityParser : IValuesParser<WeatherForecast>
    {
        public void Parse(HtmlNode frame, IList<WeatherForecast> weatherForecastForTenDays)
        {
            IList<int> geomagneticActivity = GetGeomagneticActivity(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                weatherForecastForTenDays[i].GeomagneticActivity = geomagneticActivity[i];
            }
        }

        private IList<int> GetGeomagneticActivity(HtmlNode frame) =>
            frame.SelectNodes(".//div[@class=\"widget__row widget__row_table widget__row_gm\"]/div[@class=\"widget__item\"]/div").Select(node => int.Parse(node.InnerText.Trim())).ToArray();
    }
}
