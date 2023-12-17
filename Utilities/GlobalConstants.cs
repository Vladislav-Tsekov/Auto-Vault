namespace VehicleData.Utilities
{
    public class GlobalConstants
    {
        //DATA ACCESS
        public const string FilePath = "../../../Auto-Data-Seed.csv";
        public const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=VehicleData;Integrated Security=True;";

        //DATABASE TABLE'S POPULATION
        public const string YearTablePopulated = "Year table successfully populated with entries in the range of 1984 - 2030!";
        public const string YearTableAlreadyPopulated = "Year table is already populated. Verify the data!";
        public const string AllTablesPopulated = "All tables have been successfully populated! Seeding of all vehicles will start momentarily.";

        //DATABASE QUERIES
        public const string DisableIntegrityCheck = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
        public const string EnableIntegrityCheck = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
        public const string DeleteRowsQuery = "EXEC sp_MSforeachtable @command1='SET QUOTED_IDENTIFIER ON;DELETE FROM ?'";
        public const string ReseedQuery = 
            "EXEC sp_MSforeachtable @command1='IF OBJECT_ID(''?'') IN (SELECT OBJECT_ID FROM SYS.IDENTITY_COLUMNS) DBCC CHECKIDENT(''?'', RESEED, 0)'";
    }
}
