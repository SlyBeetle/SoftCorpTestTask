using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services
{
    internal class GismeteoParser
    {
        private const int DAYS_COUNT = 10;
        private const string HOME_PAGE = @"https://www.gismeteo.ru/";
        private const string PATH_SEGMENT_FOR_TEN_DAYS_WEATHER_FORECAST = "10-days/";

        private readonly IHtmlDocumentProvider _htmlDocumentProvider;
        private readonly ICollection<IFrameParser<WeatherForecast>> _frameParsers;

        public GismeteoParser(IHtmlDocumentProvider htmlDocumentProvider, ICollection<IFrameParser<WeatherForecast>> wheatherForecastForTenDaysParsers)
        {
            _htmlDocumentProvider = htmlDocumentProvider;
            _frameParsers = wheatherForecastForTenDaysParsers;
        }

        public IList<WeatherForecast> GetWeatherForecastForTenDays(string cityUrl)
        {
            string cityUrlForTenDaysWeatherForecast = cityUrl + PATH_SEGMENT_FOR_TEN_DAYS_WEATHER_FORECAST;
            IList<WeatherForecast> weatherForecasts = new WeatherForecast[DAYS_COUNT];
            for (int i = 0; i < weatherForecasts.Count; i++)
            {
                weatherForecasts[i] = new WeatherForecast();
            }

            HtmlDocument page = _htmlDocumentProvider.GetHtmlDocument(cityUrlForTenDaysWeatherForecast);

            foreach (var frameParser in _frameParsers)
            {
                frameParser.Parse(page, weatherForecasts);
            }

            return weatherForecasts;
        }

        public IDictionary<string, string> GetUrlOfCityByCityName()
        {
            HtmlDocument homePage = _htmlDocumentProvider.GetHtmlDocument(HOME_PAGE);
            HtmlNode popularSettlementsOfRussia = homePage.DocumentNode.SelectSingleNode("//section[@class=\"cities cities_frame __frame clearfix\"]");
            IEnumerable<string> urlsOfCities = popularSettlementsOfRussia.SelectNodes(".//span[@class=\"cities_name\"]/..").Select(a => a.Attributes["href"].Value);
            IEnumerable<string> cityNames = popularSettlementsOfRussia.SelectNodes(".//following::span[2]").Select(node => node.InnerText.Trim());
            return cityNames.Zip(urlsOfCities, (cn, uc) => new { cn, uc })
              .ToDictionary(z => z.cn, z => z.uc);
        }
    }
}
