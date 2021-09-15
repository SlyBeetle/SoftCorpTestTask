using System;
using System.Data.Entity;
using GismeteoCore.Models;
using GismeteoCore.Models.WeatherForecastModels;

namespace GismeteoCore.DAL.Infrastructure
{
    public interface IDataContext : IDisposable
    {
        IDbSet<City> Cities { get; set; }
        IDbSet<WeatherForecast> WeatherForecasts { get; set; }
        Database Database { get; }

        int SaveChanges();
    }
}
