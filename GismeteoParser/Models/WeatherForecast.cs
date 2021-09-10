﻿namespace GismeteoParser.Models
{
    internal class WeatherForecast
    {
        public string Date { get; set; }

        // Centigrade
        public Temperature Temperature { get; set; } = new Temperature();

        // In meters per second
        public Wind Wind { get; set; } = new Wind();

        // In millimeters 
        public double PrecipitationTotal { get; set; }

        // In millimeters of mercury
        public Pressure Pressure { get; set; } = new Pressure();

        // In percents
        public int RelativeHumidity { get; set; }

        // In points 
        public int UltravioletIndex { get; set; }

        // Kp-index
        public int GeomagneticActivity { get; set; }
    }
}
