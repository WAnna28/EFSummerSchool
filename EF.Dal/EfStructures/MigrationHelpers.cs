using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.Dal.EfStructures
{
    public static class MigrationHelpers
    {
        // Update and Apply the Migration
        // The MigrationHelpers class has two methods for each SQL Server object: one that creates the object and
        // one that drops the object. Recall that when a migration is applied, the Up() method is executed, and when
        // a migration is rolled back, the Down() method is executed.The create static methods go into the migration’s
        // Up() method, and the drop methods go into the migration’s Down() method.When this migration is applied,
        // the two SQL Server objects are created, and when the migration is rolled back, the two SQL Server objects are dropped.

        // If you dropped your database to run the initial migration, you can apply this migration and move on.
        // Apply the migration by executing the following command:
        // dotnet ef database update -c AutoLot.Dal.EfStructures.ApplicationDbContext

        // If you did not drop your database for the first migration, the procedure already exists and can’t be
        // created.The simple fix is to comment out the call to create the stored procedure in the Up() method,

        // After you apply this migration the first time, uncomment that line, and everything will process normally.
        // Of course, another option is to delete the stored procedure from the database and then apply the migration.
        // This does break the “one place for updates” paradigm but is part of the transition from database first to code first.

        /*
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            MigrationHelpers.CreateSproc(migrationBuilder);
            MigrationHelpers.CreateCustomerOrderView(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            MigrationHelpers.DropSproc(migrationBuilder);
            MigrationHelpers.DropCustomerOrderView(migrationBuilder);
        }

     */

        public static void CreateSproc(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                exec (N' 
                CREATE PROCEDURE [dbo].[GetPetName]
                    @carID int,
                    @petName nvarchar(50) output
                AS
                    SELECT @petName = PetName from dbo.Inventory where Id = @carID
                ')");
        }
        public static void DropSproc(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[GetPetName]");
        }
        public static void CreateCustomerOrderView(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                exec (N' 
                CREATE VIEW [dbo].[CustomerOrderView]
                AS
                    SELECT dbo.Customers.FirstName, dbo.Customers.LastName, dbo.Inventory.Color, dbo.Inventory.PetName, dbo.Inventory.IsDrivable, dbo.Makes.Name AS Make
                    FROM   dbo.Orders 
                    INNER JOIN dbo.Customers ON dbo.Orders.CustomerId = dbo.Customers.Id 
                    INNER JOIN dbo.Inventory ON dbo.Orders.CarId = dbo.Inventory.Id
                    INNER JOIN dbo.Makes ON dbo.Makes.Id = dbo.Inventory.MakeId
                ')");
        }

        public static void DropCustomerOrderView(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("EXEC (N' DROP VIEW [dbo].[CustomerOrderView] ')");
        }
    }
}