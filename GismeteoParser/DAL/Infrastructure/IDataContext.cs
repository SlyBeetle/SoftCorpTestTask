using System;
using System.Data.Entity;
using GismeteoParserConsoleApplication.Models;

namespace GismeteoParserConsoleApplication.DAL.Infrastructure
{
    internal interface IDataContext : IDisposable
    {
        IDbSet<City> Cities { get; set; }
        IDbSet<WeatherForecast> WeatherForecasts { get; set; }

        int SaveChanges();
    }
}
