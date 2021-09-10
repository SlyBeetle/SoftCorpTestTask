using System.Collections.Generic;
using HtmlAgilityPack;

namespace GismeteoParser
{
    internal interface IFrameParser<T>
    {
        void Parse(HtmlDocument page, IList<T> weatherForecastForTenDays);
    }
}
