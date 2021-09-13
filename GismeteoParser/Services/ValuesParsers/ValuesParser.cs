using System;
using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers
{
    internal abstract class ValuesParser<TComplex> : IValuesParser<TComplex>
    {
        public abstract void Parse(HtmlNode frame, IList<TComplex> weatherForecastForTenDays);

        protected IList<int> GetIntegers(HtmlNode frame, string xpath) =>
            frame.SelectNodes(xpath).Select(node => int.Parse(node.InnerText.Trim())).ToList();

        protected IList<int?> GetNullableIntegers(HtmlNode frame, string xpath) =>
            frame.SelectNodes(xpath)
            .Select(node =>
            {
                int? ultravioletIndex = null;
                if (int.TryParse(node.InnerText.Trim(), out int ui))
                {
                    ultravioletIndex = ui;
                }
                return ultravioletIndex;
            })
            .ToArray();

        protected IList<string> GetStrings(HtmlNode frame, string xpath) =>
            frame.SelectNodes(xpath).Select(node => node.InnerText.Trim()).ToArray();

        protected void SetValues<TSimple>(
            HtmlNode frame,
            IList<WeatherForecast> weatherForecastForTenDays,
            Func<HtmlNode, IList<TSimple>> getSimpleValues,
            Action<WeatherForecast, TSimple> initialization)
        {
            IList<TSimple> simpleValues = getSimpleValues(frame);

            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                initialization(weatherForecastForTenDays[i], simpleValues[i]);
            }
        }

        protected void SetValues<TSimple>(
            IList<WeatherForecast> weatherForecastForTenDays,
            IList<TSimple> simpleValues,
            Action<WeatherForecast, TSimple> initialization)
        {
            for (int i = 0; i < weatherForecastForTenDays.Count; i++)
            {
                initialization(weatherForecastForTenDays[i], simpleValues[i]);
            }
        }
    }
}
