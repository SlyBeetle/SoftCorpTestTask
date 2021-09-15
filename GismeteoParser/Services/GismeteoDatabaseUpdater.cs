using System;
using GismeteoParserConsoleApplication.DAL;
using GismeteoParserConsoleApplication.DAL.Infrastructure;
using GismeteoParserConsoleApplication.Infrastructure;

namespace GismeteoParserConsoleApplication.Services
{
    internal class GismeteoDatabaseUpdater : IDatabaseUpdater
    {
        private readonly IGismeteoParser _gismeteoParser;

        public GismeteoDatabaseUpdater(IGismeteoParser gismeteoParser)
        {
            _gismeteoParser = gismeteoParser;
        }

        public void UpdateDatabase()
        {
            using (IDataContext database = new GismeteoParserContext())
            {
                database.Database.ExecuteSqlCommand("DELETE FROM Cities");
                foreach (var cityAndWeatherForecastForTenDays in _gismeteoParser.GetCitiesWithWeatherForecastForTenDays())
                {
                    database.Cities.Add(cityAndWeatherForecastForTenDays);
                    Console.WriteLine($"Parsing of weather forecasts for the {cityAndWeatherForecastForTenDays.Name} city has been completed.");
                }
                database.SaveChanges();
            }
        }
    }
}
