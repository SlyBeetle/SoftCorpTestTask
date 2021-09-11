using System.Collections.Generic;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Infrastructure
{
    internal interface IValuesParser<T>
    {
        void Parse(HtmlNode frame, IList<T> weatherForecastForTenDays);
    }
}
