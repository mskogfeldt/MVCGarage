using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCGarage.Migrations
{
    public partial class NewSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2022, 7, 11, 10, 57, 19, 905, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "ArrivalTime", "Brand", "Color", "Model", "RegistrationNumber", "Type", "WheelCount" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 7, 11, 10, 57, 19, 905, DateTimeKind.Local).AddTicks(2131), "Saab", 1, "900", "BLA222", 0, 4 },
                    { 3, new DateTime(2022, 7, 11, 10, 57, 19, 905, DateTimeKind.Local).AddTicks(2134), "BMW", 0, "320i", "ALB333", 0, 4 },
                    { 4, new DateTime(2022, 7, 11, 10, 57, 19, 905, DateTimeKind.Local).AddTicks(2137), "Toyota", 2, "Yaris", "HEY332", 1, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2022, 7, 8, 9, 38, 48, 701, DateTimeKind.Local).AddTicks(4740));
        }
    }
}
