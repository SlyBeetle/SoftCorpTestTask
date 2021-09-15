using System;
using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Services;
using GismeteoParserConsoleApplication.Services.DatabaseUpdaterProviders;

namespace GismeteoParserConsoleApplication
{
    internal class Program
    {
        private const int DATABASE_UPDATE_INTERVAL = 30000; // In milliseconds
        private static readonly IDatabaseUpdaterProvider _databaseUpdaterProvider = new SimpleDatabaseUpdaterProvider();
        private static readonly IDatabaseUpdater _databaseUpdater = _databaseUpdaterProvider.GetDatabaseUpdater();

        public static void Main()
        {
            ITimer timer = new SystemThreadingTimer(UpdateDatabase);
            timer.Start(DATABASE_UPDATE_INTERVAL);
            Console.ReadKey();
        }

        static void UpdateDatabase(object state)
        {
            _databaseUpdater.UpdateDatabase();
        }
    }
}
