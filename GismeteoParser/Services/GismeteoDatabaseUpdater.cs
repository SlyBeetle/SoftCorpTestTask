using GismeteoCore.DAL;
using GismeteoCore.DAL.Infrastructure;
using GismeteoParserConsoleApplication.Infrastructure;

namespace GismeteoParserConsoleApplication.Services
{
    internal class GismeteoDatabaseUpdater : IDatabaseUpdater
    {
        private readonly IGismeteoParser _gismeteoParser;
        private readonly ILogger _logger;

        public GismeteoDatabaseUpdater(IGismeteoParser gismeteoParser, ILogger logger)
        {
            _gismeteoParser = gismeteoParser;
            _logger = logger;
        }

        public void UpdateDatabase()
        {
            using (IDataContext database = new GismeteoContext())
            {
                _logger.Log("Starting updating the database...");
                database.Database.ExecuteSqlCommand("DELETE FROM Cities");
                foreach (var cityAndWeatherForecastForTenDays in _gismeteoParser.GetCitiesWithWeatherForecastForTenDays())
                {
                    database.Cities.Add(cityAndWeatherForecastForTenDays);
                    _logger.Log($"Parsing of weather forecasts for the {cityAndWeatherForecastForTenDays.Name} city has been completed.");
                }
                database.SaveChanges();
                _logger.Log("Update of the database is finished!");
                _logger.Log("");
            }
        }
    }
}
