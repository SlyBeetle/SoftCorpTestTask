﻿namespace GismeteoParserConsoleApplication.Models.WeatherForecastModels
{
    // In meters per second
    internal class Wind
    {
        public int? MaxVelocity { get; set; }

        public int DailyAverageVelocity { get; set; }

        public string Direction { get; set; }
    }
}