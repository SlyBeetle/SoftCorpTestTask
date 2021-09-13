﻿using System.Collections.Generic;
using System.Linq;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;
using HtmlAgilityPack;

namespace GismeteoParserConsoleApplication.Services.ValuesParsers.PressureFrame.PressureExtremumsParsers
{
    internal abstract class PressureExtremumsParser : ValuesParser<WeatherForecast>
    {
        protected IList<int> GetPressures(HtmlNode frame, string extremumType) =>
            frame.SelectNodes($".//div[@class=\"values\"]//div[@class=\"{extremumType}\"]/span[@class=\"unit unit_pressure_mm_hg_atm\"]")
            .Select(node => int.Parse(node.InnerText))
            .ToList();
    }
}
