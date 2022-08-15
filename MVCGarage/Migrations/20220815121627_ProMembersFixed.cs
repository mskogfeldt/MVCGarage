using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCGarage.Migrations
{
    public partial class ProMembersFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 9, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 8, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalDate",
                value: new DateTime(2022, 8, 15, 14, 16, 27, 74, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalDate",
                value: new DateTime(2022, 8, 15, 14, 16, 27, 74, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalDate",
                value: new DateTime(2022, 8, 15, 14, 16, 27, 74, DateTimeKind.Local).AddTicks(1158));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 9, 14, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 9, 9, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 8, 30, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 8, 25, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 8, 20, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 8, 22, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 8, 5, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalDate",
                value: new DateTime(2022, 8, 15, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(5721));

            migrationBuilder.UpdateData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalDate",
                value: new DateTime(2022, 8, 15, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(5736));

            migrationBuilder.UpdateData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalDate",
                value: new DateTime(2022, 8, 15, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(5739));
        }
    }
}
