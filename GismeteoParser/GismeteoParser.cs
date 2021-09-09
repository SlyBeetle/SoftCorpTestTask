using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using OpenQA.Selenium;

namespace GismeteoParser
{
    internal class GismeteoParser
    {
        private const string HOME_PAGE = @"https://www.gismeteo.ru/";

        private readonly IWebDriver _webDriver;

        public GismeteoParser(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IEnumerable<string> GetUrlOfCities()
        {
            _webDriver.Navigate().GoToUrl(HOME_PAGE);
            HtmlDocument homePage = new HtmlDocument();
            homePage.LoadHtml(_webDriver.PageSource);
            HtmlNodeCollection anchorsCollection = homePage.DocumentNode.SelectNodes("//section[@class=\"cities cities_frame __frame clearfix\"]//span[@class=\"cities_name\"]/..");
            return anchorsCollection.Select(a => a.Attributes["href"].Value);
        }
    }
}
