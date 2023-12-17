using Microsoft.EntityFrameworkCore;
using VehicleData.Data;
using VehicleData.Utilities;

namespace VehicleData.Core
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            VehicleDataContext context = new();
            DatabaseControl(context, shouldDropDatabase: false);

            TablePopulation data = new();
            data.YearTablePopulation(context);
            data.RestOfDataPopulation(context);

            DataSeed seeder = new();
            seeder.SeedData(context);
        }

        private static void DatabaseControl(VehicleDataContext context, bool shouldDropDatabase = false)
        {
            if (shouldDropDatabase)
            {
                context.Database.EnsureDeleted();
            }

            if (context.Database.EnsureCreated())
            {
                return;
            }

            var disableIntegrityChecksQuery = GlobalConstants.DisableIntegrityCheck;
            context.Database.ExecuteSqlRaw(disableIntegrityChecksQuery);

            var deleteRowsQuery = GlobalConstants.DeleteRowsQuery;
            context.Database.ExecuteSqlRaw(deleteRowsQuery);

            var enableIntegrityChecksQuery = GlobalConstants.EnableIntegrityCheck;
            context.Database.ExecuteSqlRaw(enableIntegrityChecksQuery);

            var reseedQuery = GlobalConstants.ReseedQuery;
            context.Database.ExecuteSqlRaw(reseedQuery);
        }
    }
}