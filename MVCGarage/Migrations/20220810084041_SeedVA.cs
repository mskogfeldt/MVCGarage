using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCGarage.Migrations
{
    public partial class SeedVA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 9, 9, 10, 40, 40, 936, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.InsertData(
                table: "VehicleAssignment",
                columns: new[] { "Id", "ArrivalDate", "PSpotsPSpotId", "VehiclesVehicleId()" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 10, 10, 40, 40, 936, DateTimeKind.Local).AddTicks(7758), 1, 1 },
                    { 2, new DateTime(2022, 8, 10, 10, 40, 40, 936, DateTimeKind.Local).AddTicks(7776), 2, 2 },
                    { 3, new DateTime(2022, 8, 10, 10, 40, 40, 936, DateTimeKind.Local).AddTicks(7779), 3, 3 },
                    { 4, new DateTime(2022, 8, 10, 10, 40, 40, 936, DateTimeKind.Local).AddTicks(7781), 4, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 9, 9, 10, 17, 43, 548, DateTimeKind.Local).AddTicks(6695));
        }
    }
}
