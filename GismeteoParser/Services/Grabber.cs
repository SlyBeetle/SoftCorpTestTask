using GismeteoParserConsoleApplication.Infrastructure;
using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;

namespace GismeteoParserConsoleApplication.Services
{
    internal class Grabber : IHtmlDocumentProvider
    {
        public HtmlDocument GetHtmlDocument(string url)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            options.AddArgument("headless");
            options.AddArgument("--blink-settings=imagesEnabled=false");

            HtmlDocument page;
            using (var _webDriver = new ChromeDriver(driverService, options))
            {
                _webDriver.Navigate().GoToUrl(url);
                page = new HtmlDocument();
                page.LoadHtml(_webDriver.PageSource);
            }
            return page;
        }
    }
}
