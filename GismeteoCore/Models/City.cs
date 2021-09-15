using System.Collections.Generic;
using System.Runtime.Serialization;
using GismeteoCore.Models.WeatherForecastModels;

namespace GismeteoCore.Models
{
    [DataContract(IsReference = true)]
    public class City
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public IList<WeatherForecast> WeatherForecasts { get; set; }
    }
}
