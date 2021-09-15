using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Services.DatabaseUpdaterProviders;

namespace GismeteoParserConsoleApplication
{
    internal class Program
    {
        public static void Main()
        {
            IDatabaseUpdaterProvider databaseUpdaterProvider = new SimpleDatabaseUpdaterProvider();
            IDatabaseUpdater databaseUpdater = databaseUpdaterProvider.GetDatabaseUpdater();
            databaseUpdater.UpdateDatabase();
        }
    }
}
