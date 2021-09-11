using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.FrameParsers
{
    internal abstract class FrameParser : IFrameParser<WeatherForecast>
    {
        protected readonly ICollection<IValuesParser<WeatherForecast>> _valuesParsers;
        protected HtmlNode _frame;

        protected FrameParser(ICollection<IValuesParser<WeatherForecast>> valuesParsers)
        {
            _valuesParsers = valuesParsers;
        }

        public abstract void Parse(HtmlDocument page, IList<WeatherForecast> weatherForecastForTenDays);

        protected void ExecuteValuesParsers(IList<WeatherForecast> weatherForecastForTenDays)
        {
            foreach (var valuesParser in _valuesParsers)
            {
                valuesParser.Parse(_frame, weatherForecastForTenDays);
            }
        }

        protected string GetFrameXPathByIndexNumber(int indexNumber) => $"//div[@class=\"__frame_sm\"]/*[{indexNumber}]";
    }
}
