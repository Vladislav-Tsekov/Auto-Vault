using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleData.Migrations
{
    /// <inheritdoc />
    public partial class EngineMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Engine__Vehicle__4D94879B",
                table: "Engine");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Engine__3214EC07D6C466BC",
                table: "Engine");

            migrationBuilder.DropIndex(
                name: "IX_Engine_Vehicle",
                table: "Engine");

            migrationBuilder.DropColumn(
                name: "Vehicle",
                table: "Engine");

            migrationBuilder.AddColumn<int>(
                name: "Engine",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Engine",
                table: "Engine",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Engine",
                table: "Vehicle",
                column: "Engine");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Engine_Engine",
                table: "Vehicle",
                column: "Engine",
                principalTable: "Engine",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Engine_Engine",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_Engine",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Engine",
                table: "Engine");

            migrationBuilder.DropColumn(
                name: "Engine",
                table: "Vehicle");

            migrationBuilder.AddColumn<int>(
                name: "Vehicle",
                table: "Engine",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Engine__3214EC07D6C466BC",
                table: "Engine",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Engine_Vehicle",
                table: "Engine",
                column: "Vehicle");

            migrationBuilder.AddForeignKey(
                name: "FK__Engine__Vehicle__4D94879B",
                table: "Engine",
                column: "Vehicle",
                principalTable: "Vehicle",
                principalColumn: "Id");
        }
    }
}
