using HtmlAgilityPack;

namespace GismeteoParser
{
    internal interface IHtmlDocumentProvider
    {
        HtmlDocument GetHtmlDocument(string url);
    }
}
