using System.Data.Entity;
using GismeteoCore.DAL.Infrastructure;
using GismeteoCore.Models;
using GismeteoCore.Models.WeatherForecastModels;

namespace GismeteoCore.DAL
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class GismeteoContext : DbContext, IDataContext
    {
        private const string NAME_OF_DATABASE_CONNECTION_STRING = "GismeteoParserDbConnection";

        public GismeteoContext() : base(NAME_OF_DATABASE_CONNECTION_STRING)
        {
        }

        public IDbSet<City> Cities { get; set; }
        public IDbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
