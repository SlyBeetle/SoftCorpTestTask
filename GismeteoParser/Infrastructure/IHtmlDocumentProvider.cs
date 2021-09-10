using HtmlAgilityPack;

namespace GismeteoParser.Infrastructure
{
    internal interface IHtmlDocumentProvider
    {
        HtmlDocument GetHtmlDocument(string url);
    }
}
