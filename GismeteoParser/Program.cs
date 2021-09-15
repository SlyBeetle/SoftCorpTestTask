using System;
using System.Threading;
using GismeteoParserConsoleApplication.Infrastructure;
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
            Timer timer = new Timer(UpdateDatabase, null, 0, DATABASE_UPDATE_INTERVAL);
            Console.ReadKey();
        }

        static void UpdateDatabase(object state)
        {
            _databaseUpdater.UpdateDatabase();
        }
    }
}
