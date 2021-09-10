using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Infrastructure
{
    internal interface IHtmlDocumentProvider
    {
        HtmlDocument GetHtmlDocument(string url);
    }
}
