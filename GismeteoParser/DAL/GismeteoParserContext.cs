using System.Data.Entity;
using GismeteoParserConsoleApplication.DAL.Infrastructure;
using GismeteoParserConsoleApplication.Models;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;

namespace GismeteoParserConsoleApplication.DAL
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    internal class GismeteoParserContext : DbContext, IDataContext
    {
        private const string NAME_OF_DATABASE_CONNECTION_STRING = "GismeteoParserDbConnection";

        public GismeteoParserContext() : base(NAME_OF_DATABASE_CONNECTION_STRING)
        {
        }

        public IDbSet<City> Cities { get; set; }
        public IDbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
