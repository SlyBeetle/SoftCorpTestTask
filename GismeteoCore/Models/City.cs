using System.Collections.Generic;
using GismeteoCore.Models.WeatherForecastModels;

namespace GismeteoCore.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<WeatherForecast> WeatherForecasts { get; set; }
    }
}
