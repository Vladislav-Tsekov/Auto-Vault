using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleData.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrivetrainType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drive = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DriveTyp__3214EC071020DF99", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transmission = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transmis__3214EC07F70BE21B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VehicleC__3214EC071A710D73", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturingYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Year__3214EC076BD48B66", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: true),
                    Model = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: true),
                    DrivetrainType = table.Column<int>(type: "int", nullable: true),
                    TransmissionType = table.Column<int>(type: "int", nullable: true),
                    VehicleSizeClass = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    BaseModel = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vehicle__3214EC0792FBCB96", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Vehicle__DriveTy__47DBAE45",
                        column: x => x.DrivetrainType,
                        principalTable: "DrivetrainType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Vehicle__Transmi__48CFD27E",
                        column: x => x.TransmissionType,
                        principalTable: "TransmissionType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Vehicle__Vehicle__49C3F6B7",
                        column: x => x.VehicleSizeClass,
                        principalTable: "VehicleClass",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Vehicle__Year__4AB81AF0",
                        column: x => x.Year,
                        principalTable: "Year",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle = table.Column<int>(type: "int", nullable: true),
                    Displacement = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Engine__3214EC07D6C466BC", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Engine__Vehicle__4D94879B",
                        column: x => x.Vehicle,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Engine_Vehicle",
                table: "Engine",
                column: "Vehicle");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DrivetrainType",
                table: "Vehicle",
                column: "DrivetrainType");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TransmissionType",
                table: "Vehicle",
                column: "TransmissionType");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleSizeClass",
                table: "Vehicle",
                column: "VehicleSizeClass");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Year",
                table: "Vehicle",
                column: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "DrivetrainType");

            migrationBuilder.DropTable(
                name: "TransmissionType");

            migrationBuilder.DropTable(
                name: "VehicleClass");

            migrationBuilder.DropTable(
                name: "Year");
        }
    }
}
