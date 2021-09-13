using System;
using System.Data.Entity;
using GismeteoParserConsoleApplication.Models;
using GismeteoParserConsoleApplication.Models.WeatherForecastModels;

namespace GismeteoParserConsoleApplication.DAL.Infrastructure
{
    internal interface IDataContext : IDisposable
    {
        IDbSet<City> Cities { get; set; }
        IDbSet<WeatherForecast> WeatherForecasts { get; set; }
        Database Database { get; }

        int SaveChanges();
    }
}
