using Microsoft.EntityFrameworkCore.Migrations;

namespace SeniorProject.Migrations
{
    public partial class mshnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LabDayId",
                table: "Experiment",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LabDayId",
                table: "Experiment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
