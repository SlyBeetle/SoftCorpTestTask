using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using GismeteoCore.DAL;
using GismeteoCore.DAL.Infrastructure;
using GismeteoCore.Models;

namespace GismeteoService.Controllers
{
    public class CitiesController : ApiController
    {
        private readonly IDataContext _database = new GismeteoContext();

        public IEnumerable<City> GetCities()
        {
            var citiesWithWeatherForecasts = _database.Cities.Include(c => c.WeatherForecasts).ToArray();
            return citiesWithWeatherForecasts;
        }
    }
}
