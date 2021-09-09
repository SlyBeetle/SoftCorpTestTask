namespace GismeteoParser.Models
{
    internal class WeatherForecast
    {
        public string Date { get; set; }

        // Centigrade
        public Temperature Temperature { get; set; }

        // In meters per second
        public Wind Wind { get; set; }

        // In millimeters 
        public int PrecipitationTotal { get; set; }

        // In millimeters of mercury
        public Pressure Pressure { get; set; }

        // In percents
        public int RelativeHumidity { get; set; }

        // In points 
        public int UltravioletIndex { get; set; }

        // Kp-index
        public int GeomagneticActivity { get; set; }
    }
}
