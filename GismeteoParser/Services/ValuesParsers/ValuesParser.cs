using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers
{
    internal abstract class ValuesParser<T> : IValuesParser<T>
    {
        public abstract void Parse(HtmlNode frame, IList<T> weatherForecastForTenDays);

        protected IList<int> GetIntegers(HtmlNode frame, string xpath) =>
            frame.SelectNodes(xpath).Select(node => int.Parse(node.InnerText.Trim())).ToArray();
    }
}
