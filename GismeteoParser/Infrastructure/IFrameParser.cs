using System.Collections.Generic;
using HtmlAgilityPack;

namespace GismeteoParser.Infrastructure
{
    internal interface IFrameParser<T>
    {
        void Parse(HtmlDocument page, IList<T> weatherForecastForTenDays);
    }
}
