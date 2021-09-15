﻿using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;

namespace GismeteoParserConsoleApplication.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<WeatherForecast> WeatherForecasts { get; set; }
    }
}