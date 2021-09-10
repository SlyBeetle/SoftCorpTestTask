using GismeteoParserConsoleApplication.Infrastructure;
using HtmlAgilityPack;
using OpenQA.Selenium;

namespace GismeteoParserConsoleApplication.Services
{
    internal class Grabber : IHtmlDocumentProvider
    {
        private readonly IWebDriver _webDriver;

        public Grabber(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public HtmlDocument GetHtmlDocument(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
            HtmlDocument page = new HtmlDocument();
            page.LoadHtml(_webDriver.PageSource);
            return page;
        }
    }
}
