using System.Data.Entity;
using GismeteoParserConsoleApplication.DAL.Infrastructure;
using GismeteoParserConsoleApplication.Models;

namespace GismeteoParserConsoleApplication.DAL
{
    internal class GismeteoParserContext : DbContext, IDataContext
    {
        private const string NAME_OF_DATABASE_CONNECTION_STRING = "GismeteoParserDbConnection";

        public GismeteoParserContext() : base(NAME_OF_DATABASE_CONNECTION_STRING)
        {
        }

        public IDbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
