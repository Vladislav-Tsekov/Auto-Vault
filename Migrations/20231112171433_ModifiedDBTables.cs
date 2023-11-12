using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleData.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedDBTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Model",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(75)",
                oldUnicode: false,
                oldMaxLength: 75,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Make",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(75)",
                oldUnicode: false,
                oldMaxLength: 75,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BaseModel",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(75)",
                oldUnicode: false,
                oldMaxLength: 75,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BaseModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_BaseModel",
                table: "Vehicle",
                column: "BaseModel");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Make",
                table: "Vehicle",
                column: "Make");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Model",
                table: "Vehicle",
                column: "Model");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_BaseModels_BaseModel",
                table: "Vehicle",
                column: "BaseModel",
                principalTable: "BaseModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Makes_Make",
                table: "Vehicle",
                column: "Make",
                principalTable: "Makes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Models_Model",
                table: "Vehicle",
                column: "Model",
                principalTable: "Models",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_BaseModels_BaseModel",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Makes_Make",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Models_Model",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "BaseModels");

            migrationBuilder.DropTable(
                name: "Makes");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_BaseModel",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_Make",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_Model",
                table: "Vehicle");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicle",
                type: "varchar(75)",
                unicode: false,
                maxLength: 75,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Vehicle",
                type: "varchar(75)",
                unicode: false,
                maxLength: 75,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BaseModel",
                table: "Vehicle",
                type: "varchar(75)",
                unicode: false,
                maxLength: 75,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
