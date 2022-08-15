using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCGarage.Migrations
{
    public partial class SeedPersonalIdentityNumberValid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19810701-2018", new DateTime(2022, 9, 14, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1398) });

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19810702-4351", new DateTime(2022, 9, 9, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1434) });

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19810703-0614", new DateTime(2022, 8, 30, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1438) });

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19810704-0373", new DateTime(2022, 8, 25, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19810705-5330", new DateTime(2022, 8, 20, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1444) });

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19810706-5016", new DateTime(2022, 8, 22, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1448) });

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19010101-3530", new DateTime(2022, 8, 5, 13, 30, 37, 358, DateTimeKind.Local).AddTicks(1451) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19810701-6666", new DateTime(2022, 9, 10, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9868) });

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19810702-6666", new DateTime(2022, 9, 5, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9902) });

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19810703-6666", new DateTime(2022, 8, 26, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9904) });

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19810704-6666", new DateTime(2022, 8, 21, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9906) });

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19810705-6666", new DateTime(2022, 8, 16, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9908) });

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19810706-6666", new DateTime(2022, 8, 18, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9910) });

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[] { "19010101-6666", new DateTime(2022, 8, 1, 22, 14, 10, 739, DateTimeKind.Local).AddTicks(9912) });

            migrationBuilder.UpdateData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalDate",
                value: new DateTime(2022, 8, 11, 22, 14, 10, 740, DateTimeKind.Local).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalDate",
                value: new DateTime(2022, 8, 11, 22, 14, 10, 740, DateTimeKind.Local).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "VehicleAssignment",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalDate",
                value: new DateTime(2022, 8, 11, 22, 14, 10, 740, DateTimeKind.Local).AddTicks(3158));
        }
    }
}
