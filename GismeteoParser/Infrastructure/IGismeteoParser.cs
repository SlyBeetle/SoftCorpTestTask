using System.Collections.Generic;
using GismeteoParserConsoleApplication.Models;

namespace GismeteoParserConsoleApplication.Infrastructure
{
    internal interface IGismeteoParser
    {
        IList<City> GetCitiesWithWeatherForecastForTenDays();
    }
}
