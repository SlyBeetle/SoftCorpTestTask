using System;
using System.Linq;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace GismeteoParser
{
    internal class Program
    {
        private const string HOME_PAGE = @"https://www.gismeteo.ru/";

        static void Main()
        {
            IWebDriver driver = new PhantomJSDriver();
            driver.Navigate().GoToUrl(HOME_PAGE);
            HtmlDocument homePage = new HtmlDocument();
            homePage.LoadHtml(driver.PageSource);
            HtmlNodeCollection anchorsCollection = homePage.DocumentNode.SelectNodes("//section[@class=\"cities cities_frame __frame clearfix\"]//span[@class=\"cities_name\"]/..");
            var urlOfCities = anchorsCollection.Select(a => a.Attributes["href"].Value);
            Console.WriteLine();
            foreach (string url in urlOfCities)
            {
                Console.WriteLine(url);
            }
            Console.ReadKey();
        }
    }
}
