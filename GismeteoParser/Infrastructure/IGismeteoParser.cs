using System.Collections.Generic;
using GismeteoCore.Models;

namespace GismeteoParserConsoleApplication.Infrastructure
{
    internal interface IGismeteoParser
    {
        IList<City> GetCitiesWithWeatherForecastForTenDays();
    }
}
