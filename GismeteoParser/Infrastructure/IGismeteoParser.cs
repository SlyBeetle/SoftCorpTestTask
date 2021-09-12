using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models;

namespace GismeteoParserConsoleApplication.Infrastructure
{
    internal interface IGismeteoParser
    {
        IDictionary<string, IList<WeatherForecast>> GetWeatherForecastForTenDaysByCity();
    }
}
