using GismeteoParserConsoleApplication.Infrastructure;
using GismeteoParserConsoleApplication.Services;
using GismeteoParserConsoleApplication.Services.GismeteoParserProviders;

namespace GismeteoParserConsoleApplication
{
    internal class Program
    {
        public static void Main()
        {
            IGismeteoParserProvider gismeteoParserProvider = new SimpleGismeteoParserProvider();
            IGismeteoParser gismeteoParser = gismeteoParserProvider.GetGismeteoParser();
            IDatabaseUpdater databaseUpdater = new GismeteoDatabaseUpdater();
            databaseUpdater.UpdateDatabase(gismeteoParser);
        }
    }
}
