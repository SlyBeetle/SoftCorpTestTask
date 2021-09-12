using System;
using System.Data.Entity;
using GismeteoParserConsoleApplication.Models;

namespace GismeteoParserConsoleApplication.DAL.Infrastructure
{
    internal interface IDataContext : IDisposable
    {
        IDbSet<WeatherForecast> WeatherForecasts { get; set; }

        int SaveChanges();
    }
}
