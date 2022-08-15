using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCGarage.Migrations
{
    public partial class testar5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProMembershipToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalIdentityNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HasReceived2YearsProMembership = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PSpot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSpot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NeededSize = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    WheelCount = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    PSpotsPSpotId = table.Column<int>(type: "int", nullable: false),
                    VehiclesVehicleId = table.Column<int>(name: "VehiclesVehicleId()", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleAssignment_PSpot_PSpotsPSpotId",
                        column: x => x.PSpotsPSpotId,
                        principalTable: "PSpot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleAssignment_Vehicle_VehiclesVehicleId()",
                        column: x => x.VehiclesVehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "FirstName", "HasReceived2YearsProMembership", "LastName", "PersonalIdentityNumber", "ProMembershipToDate" },
                values: new object[,]
                {
                    { 1, "Kalle", false, "Larsson", "19810701-6666", new DateTime(2022, 9, 14, 17, 11, 4, 800, DateTimeKind.Local).AddTicks(1134) },
                    { 2, "Kolle", false, "Persson", "19810702-6666", new DateTime(2022, 9, 9, 17, 11, 4, 800, DateTimeKind.Local).AddTicks(1159) },
                    { 3, "Koklan", false, "Sigvardsson", "19810703-6666", new DateTime(2022, 8, 30, 17, 11, 4, 800, DateTimeKind.Local).AddTicks(1161) },
                    { 4, "Kille", false, "Andersson", "19810704-6666", new DateTime(2022, 8, 25, 17, 11, 4, 800, DateTimeKind.Local).AddTicks(1163) },
                    { 5, "Ablin", false, "Dahlstedt", "19810705-6666", new DateTime(2022, 8, 20, 17, 11, 4, 800, DateTimeKind.Local).AddTicks(1164) },
                    { 6, "Sara", false, "Larsson", "19810706-6666", new DateTime(2022, 8, 22, 17, 11, 4, 800, DateTimeKind.Local).AddTicks(1166) },
                    { 7, "FlygAnders", true, "Highlander", "19010101-6666", new DateTime(2022, 8, 5, 17, 11, 4, 800, DateTimeKind.Local).AddTicks(1168) }
                });

            migrationBuilder.InsertData(
                table: "PSpot",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10
                });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "Name", "NeededSize" },
                values: new object[,]
                {
                    { 1, "Car", 1.0 },
                    { 2, "Motorcycle", 0.33000000000000002 },
                    { 3, "Airplane", 8.0 }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Brand", "Color", "MemberId", "Model", "RegistrationNumber", "VehicleTypeId", "WheelCount" },
                values: new object[,]
                {
                    { 1, "Volvo", 2, 1, "240", "ABC123", 1, 4 },
                    { 2, "Saab", 1, 1, "900", "BLA222", 1, 4 },
                    { 3, "BMW", 0, 1, "320i", "ALB333", 1, 4 },
                    { 4, "Honda", 2, 2, "MT-07", "MOT123", 2, 2 },
                    { 5, "Yamaha", 5, 2, "XT500", "YAM456", 2, 2 },
                    { 6, "Suzuki", 2, 2, "350", "SUZ111", 2, 2 },
                    { 7, "Honda", 6, 3, "MT-07", "MOT456", 2, 2 },
                    { 8, "Yamaha", 4, 3, "XT500", "YAM789", 2, 2 },
                    { 9, "Suzuki", 1, 3, "750", "SUZ222", 2, 2 },
                    { 10, "Honda", 0, 4, "MT-07", "MOT777", 2, 2 },
                    { 11, "Yamaha", 3, 4, "XT500", "YAM888", 2, 2 },
                    { 12, "Suzuki", 7, 4, "1050", "SUZ333", 2, 2 },
                    { 13, "Boeing", 6, 7, "C-73", "FFF111", 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "VehicleAssignment",
                columns: new[] { "Id", "ArrivalDate", "PSpotsPSpotId", "VehiclesVehicleId()" },
                values: new object[] { 1, new DateTime(2022, 8, 15, 17, 11, 4, 800, DateTimeKind.Local).AddTicks(4046), 1, 1 });

            migrationBuilder.InsertData(
                table: "VehicleAssignment",
                columns: new[] { "Id", "ArrivalDate", "PSpotsPSpotId", "VehiclesVehicleId()" },
                values: new object[] { 2, new DateTime(2022, 8, 15, 17, 11, 4, 800, DateTimeKind.Local).AddTicks(4055), 2, 2 });

            migrationBuilder.InsertData(
                table: "VehicleAssignment",
                columns: new[] { "Id", "ArrivalDate", "PSpotsPSpotId", "VehiclesVehicleId()" },
                values: new object[] { 3, new DateTime(2022, 8, 15, 17, 11, 4, 800, DateTimeKind.Local).AddTicks(4057), 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Member_PersonalIdentityNumber",
                table: "Member",
                column: "PersonalIdentityNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_MemberId",
                table: "Vehicle",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_RegistrationNumber",
                table: "Vehicle",
                column: "RegistrationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAssignment_PSpotsPSpotId",
                table: "VehicleAssignment",
                column: "PSpotsPSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAssignment_VehiclesVehicleId()",
                table: "VehicleAssignment",
                column: "VehiclesVehicleId()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleAssignment");

            migrationBuilder.DropTable(
                name: "PSpot");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
