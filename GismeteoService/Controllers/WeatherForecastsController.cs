using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GismeteoCore.DAL;
using GismeteoCore.DAL.Infrastructure;
using GismeteoCore.Models.WeatherForecastModels;

namespace GismeteoService.Controllers
{
    public class WeatherForecastsController : ApiController
    {
        private readonly IDataContext _database = new GismeteoContext();

        public IEnumerable<WeatherForecast> GetWeatherForecast(int cityId)
        {
            return _database.WeatherForecasts.Where(weatherForecast => weatherForecast.CityId == cityId);
        }
    }
}
