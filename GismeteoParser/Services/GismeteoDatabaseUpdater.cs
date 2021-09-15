using System;
using GismeteoParserConsoleApplication.DAL;
using GismeteoParserConsoleApplication.DAL.Infrastructure;
using GismeteoParserConsoleApplication.Infrastructure;

namespace GismeteoParserConsoleApplication.Services
{
    internal class GismeteoDatabaseUpdater : IDatabaseUpdater
    {
        public void UpdateDatabase(IGismeteoParser gismeteoParser)
        {
            using (IDataContext database = new GismeteoParserContext())
            {
                database.Database.ExecuteSqlCommand("DELETE FROM Cities");
                foreach (var cityAndWeatherForecastForTenDays in gismeteoParser.GetCitiesWithWeatherForecastForTenDays())
                {
                    Console.WriteLine(cityAndWeatherForecastForTenDays.Name + ": ");
                    database.Cities.Add(cityAndWeatherForecastForTenDays);
                    foreach (var weatherForecast in cityAndWeatherForecastForTenDays.WeatherForecasts)
                    {
                        Console.Write(weatherForecast.Date + "; ");
                        Console.Write(weatherForecast.Temperature.Max + "; ");
                        Console.Write(weatherForecast.Temperature.Min + "; ");
                        Console.Write(weatherForecast.PrecipitationTotal + "; ");
                        Console.Write(weatherForecast.Temperature.DailyAverage + "; ");
                        Console.Write(weatherForecast.Wind.DailyAverageVelocity + "; ");
                        Console.Write(weatherForecast.Wind.MaxVelocity + "; ");
                        Console.Write(weatherForecast.Wind.Direction + "; ");
                        Console.Write(weatherForecast.Pressure.Max + "; ");
                        Console.Write(weatherForecast.Pressure.Min + "; ");
                        Console.Write(weatherForecast.RelativeHumidity + "; ");
                        Console.Write(weatherForecast.UltravioletIndex + "; ");
                        Console.Write(weatherForecast.GeomagneticActivity + "; ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                database.SaveChanges();
            }
        }
    }
}
