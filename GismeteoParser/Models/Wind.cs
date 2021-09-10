namespace GismeteoParserConsoleApplication.Models
{
    // In meters per second
    internal class Wind
    {
        public int MaxVelocity { get; set; }

        public int DailyAverage { get; set; }

        public string WindDirection { get; set; }
    }
}
