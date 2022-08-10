using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCGarage.Migrations
{
    public partial class SeedDataTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 9, 9, 10, 17, 43, 548, DateTimeKind.Local).AddTicks(6695));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProMembershipToDate",
                value: new DateTime(2022, 9, 8, 14, 19, 45, 930, DateTimeKind.Local).AddTicks(2827));
        }
    }
}
