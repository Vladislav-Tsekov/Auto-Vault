using Microsoft.EntityFrameworkCore;
using VehicleData.Data;

namespace VehicleData.Core
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            VehicleDataContext context = new();
            DatabaseControl(context, shouldDropDatabase: false);

            DataPopulation data = new();
            data.YearTablePopulation(context);
            data.RestOfDataPopulation(context);

            Controller controller = new();
            controller.SeedData();
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

            var disableIntegrityChecksQuery = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
            context.Database.ExecuteSqlRaw(disableIntegrityChecksQuery);

            var deleteRowsQuery = "EXEC sp_MSforeachtable @command1='SET QUOTED_IDENTIFIER ON;DELETE FROM ?'";
            context.Database.ExecuteSqlRaw(deleteRowsQuery);

            var enableIntegrityChecksQuery =
                "EXEC sp_MSforeachtable @command1='ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
            context.Database.ExecuteSqlRaw(enableIntegrityChecksQuery);

            var reseedQuery =
                "EXEC sp_MSforeachtable @command1='IF OBJECT_ID(''?'') IN (SELECT OBJECT_ID FROM SYS.IDENTITY_COLUMNS) DBCC CHECKIDENT(''?'', RESEED, 0)'";
            context.Database.ExecuteSqlRaw(reseedQuery);
        }
    }
}