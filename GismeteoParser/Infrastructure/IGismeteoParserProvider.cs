namespace GismeteoParserConsoleApplication.Infrastructure
{
    internal interface IDatabaseUpdaterProvider
    {
        IDatabaseUpdater GetDatabaseUpdater();
    }
}
