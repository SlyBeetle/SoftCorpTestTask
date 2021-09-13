using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services
{
    internal class GismeteoParser : IGismeteoParser
    {
        private const int DAYS_COUNT = 10;
        private const string HOME_PAGE = @"https://www.gismeteo.ru";
        private const string PATH_SEGMENT_FOR_TEN_DAYS_WEATHER_FORECAST = "10-days/";

        private readonly IHtmlDocumentProvider _htmlDocumentProvider;
        private readonly ICollection<IFrameParser<WeatherForecast>> _frameParsers;

        public GismeteoParser(IHtmlDocumentProvider htmlDocumentProvider, ICollection<IFrameParser<WeatherForecast>> wheatherForecastForTenDaysParsers)
        {
            _htmlDocumentProvider = htmlDocumentProvider;
            _frameParsers = wheatherForecastForTenDaysParsers;
        }

        public IList<City> GetCitiesWithWeatherForecastForTenDays()
        {
            var urlOfCityByCityName = GetUrlOfCityByCityName();
            var citiesWithWeatherForecastForTenDays = new List<City>(urlOfCityByCityName.Count);
            foreach (var nameAndUrl in urlOfCityByCityName)
            {
                City city = new City
                {
                    Name = nameAndUrl.Key,
                    WeatherForecasts = GetWeatherForecastForTenDays(nameAndUrl.Value)
                };
                citiesWithWeatherForecastForTenDays.Add(city);
            }
            return citiesWithWeatherForecastForTenDays;
        }

        private IList<WeatherForecast> GetWeatherForecastForTenDays(string cityUrl)
        {
            string cityUrlForTenDaysWeatherForecast = HOME_PAGE + cityUrl + PATH_SEGMENT_FOR_TEN_DAYS_WEATHER_FORECAST;
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

        private IDictionary<string, string> GetUrlOfCityByCityName()
        {
            HtmlDocument homePage = _htmlDocumentProvider.GetHtmlDocument(HOME_PAGE);
            HtmlNode popularSettlementsOfRussia = homePage.DocumentNode.SelectSingleNode("//div[@class=\"js_cities_pcities cities_section\"]");
            const string XPATH_FOR_CITY_NAMES = "./div[@class=\"cities_list\"]//span[@class=\"cities_name\"]";
            IEnumerable<string> urlsOfCities = popularSettlementsOfRussia.SelectNodes($"{XPATH_FOR_CITY_NAMES}/..").Select(a => a.Attributes["href"].Value);
            IEnumerable<string> cityNames = popularSettlementsOfRussia.SelectNodes(XPATH_FOR_CITY_NAMES).Select(node => node.InnerText.Trim());
            return cityNames.Zip(urlsOfCities, (cn, uc) => new { cn, uc })
              .ToDictionary(z => z.cn, z => z.uc);
        }
    }
}
