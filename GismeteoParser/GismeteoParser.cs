using System.Collections.Generic;
using System.Linq;
using GismeteoParser.Models;
using HtmlAgilityPack;

namespace GismeteoParser
{
    internal class GismeteoParser
    {
        private const string HOME_PAGE = @"https://www.gismeteo.ru/";

        private readonly IHtmlDocumentProvider _htmlDocumentProvider;
        private readonly ICollection<IFrameParser<WeatherForecast>> _wheatherForecastForTenDaysParsers;

        public GismeteoParser(IHtmlDocumentProvider htmlDocumentProvider, ICollection<IFrameParser<WeatherForecast>> wheatherForecastForTenDaysParsers)
        {
            _htmlDocumentProvider = htmlDocumentProvider;
            _wheatherForecastForTenDaysParsers = wheatherForecastForTenDaysParsers;
        }

        private IEnumerable<string> GetUrlOfCities()
        {
            HtmlDocument homePage = _htmlDocumentProvider.GetHtmlDocument(HOME_PAGE);
            HtmlNodeCollection anchorsCollection = homePage.DocumentNode.SelectNodes("//section[@class=\"cities cities_frame __frame clearfix\"]//span[@class=\"cities_name\"]/..");
            return anchorsCollection.Select(a => a.Attributes["href"].Value);
        }
    }
}
