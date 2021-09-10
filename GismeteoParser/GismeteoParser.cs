﻿using System.Collections.Generic;
using System.Linq;
using GismeteoParser.Infrastructure;
using GismeteoParser.Models;
using HtmlAgilityPack;

namespace GismeteoParser
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

        private IEnumerable<string> GetUrlOfCities()
        {
            HtmlDocument homePage = _htmlDocumentProvider.GetHtmlDocument(HOME_PAGE);
            HtmlNodeCollection anchorsCollection = homePage.DocumentNode.SelectNodes("//section[@class=\"cities cities_frame __frame clearfix\"]//span[@class=\"cities_name\"]/..");
            return anchorsCollection.Select(a => a.Attributes["href"].Value);
        }
    }
}
