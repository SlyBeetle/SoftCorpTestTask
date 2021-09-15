namespace GismeteoParserConsoleApplication.Infrastructure
{
    internal interface IDatabaseUpdater
    {
        void UpdateDatabase(IGismeteoParser gismeteoParser);
    }
}
