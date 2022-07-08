using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCGarage.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkedVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    WheelCount = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicle", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "ArrivalTime", "Brand", "Color", "Model", "RegistrationNumber", "Type", "WheelCount" },
                values: new object[] { 1, new DateTime(2022, 7, 8, 9, 38, 48, 701, DateTimeKind.Local).AddTicks(4740), "Volvo", 2, "240", "ABC-123", 0, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_RegistrationNumber",
                table: "ParkedVehicle",
                column: "RegistrationNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkedVehicle");
        }
    }
}
