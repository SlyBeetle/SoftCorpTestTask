using System.Collections.Generic;

namespace GismeteoParserConsoleApplication.Models
{
    internal class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<WeatherForecast> WeatherForecasts { get; set; }
    }
}
