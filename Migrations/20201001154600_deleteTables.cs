using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeniorProject.Migrations
{
    public partial class deleteTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestingAndCalibration_Machine_machineId",
                table: "TestingAndCalibration");

            migrationBuilder.DropTable(
                name: "UsedEquipment");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropIndex(
                name: "IX_TestingAndCalibration_machineId",
                table: "TestingAndCalibration");

            migrationBuilder.DropColumn(
                name: "machineId",
                table: "TestingAndCalibration");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "TestingAndCalibration",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "calibration",
                table: "Equipment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "exId",
                table: "Equipment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ex_id",
                table: "Equipment",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "from",
                table: "Equipment",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "quantityUsed",
                table: "Equipment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "serialNumber",
                table: "Equipment",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "to",
                table: "Equipment",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_TestingAndCalibration_EquipmentId",
                table: "TestingAndCalibration",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ex_id",
                table: "Equipment",
                column: "ex_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Experiment_ex_id",
                table: "Equipment",
                column: "ex_id",
                principalTable: "Experiment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestingAndCalibration_Equipment_EquipmentId",
                table: "TestingAndCalibration",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Experiment_ex_id",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_TestingAndCalibration_Equipment_EquipmentId",
                table: "TestingAndCalibration");

            migrationBuilder.DropIndex(
                name: "IX_TestingAndCalibration_EquipmentId",
                table: "TestingAndCalibration");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_ex_id",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "TestingAndCalibration");

            migrationBuilder.DropColumn(
                name: "calibration",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "exId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "ex_id",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "from",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "quantityUsed",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "serialNumber",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "to",
                table: "Equipment");

            migrationBuilder.AddColumn<int>(
                name: "machineId",
                table: "TestingAndCalibration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    arrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    calibration = table.Column<bool>(type: "bit", nullable: false),
                    expiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    room = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsedEquipment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipmentID = table.Column<int>(type: "int", nullable: false),
                    exId = table.Column<int>(type: "int", nullable: false),
                    ex_id = table.Column<int>(type: "int", nullable: true),
                    from = table.Column<DateTime>(type: "datetime2", nullable: false),
                    machineID = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    to = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedEquipment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsedEquipment_Equipment_equipmentID",
                        column: x => x.equipmentID,
                        principalTable: "Equipment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsedEquipment_Experiment_ex_id",
                        column: x => x.ex_id,
                        principalTable: "Experiment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsedEquipment_Machine_machineID",
                        column: x => x.machineID,
                        principalTable: "Machine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestingAndCalibration_machineId",
                table: "TestingAndCalibration",
                column: "machineId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedEquipment_equipmentID",
                table: "UsedEquipment",
                column: "equipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_UsedEquipment_ex_id",
                table: "UsedEquipment",
                column: "ex_id");

            migrationBuilder.CreateIndex(
                name: "IX_UsedEquipment_machineID",
                table: "UsedEquipment",
                column: "machineID");

            migrationBuilder.AddForeignKey(
                name: "FK_TestingAndCalibration_Machine_machineId",
                table: "TestingAndCalibration",
                column: "machineId",
                principalTable: "Machine",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
