﻿using System.Collections.Generic;
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

        // Starting from one
        protected void SetFrameByIndexNumber(HtmlDocument page, int indexNumber) => _frame = page.DocumentNode.SelectSingleNode(GetFrameXPathByIndexNumber(indexNumber));

        // Starting from one
        private string GetFrameXPathByIndexNumber(int indexNumber) => $"//div[@class=\"__frame_sm\"]/div[{indexNumber}]";
    }
}
