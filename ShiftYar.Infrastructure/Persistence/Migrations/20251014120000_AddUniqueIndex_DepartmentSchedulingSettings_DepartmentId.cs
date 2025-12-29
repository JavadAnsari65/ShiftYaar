using Microsoft.EntityFrameworkCore.Migrations;

namespace ShiftYar.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndex_DepartmentSchedulingSettings_DepartmentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add numeric columns for department scheduling settings
            migrationBuilder.AddColumn<int>(
                name: "MinRestDaysBetweenShifts",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxConsecutiveShifts",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxShiftsPerWeek",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxNightShiftsPerMonth",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxShiftsPerDay",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxConsecutiveNightShifts",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);
            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSchedulingSettings_DepartmentId",
                table: "DepartmentSchedulingSettings",
                column: "DepartmentId",
                unique: true,
                filter: "[DepartmentId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinRestDaysBetweenShifts",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MaxConsecutiveShifts",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MaxShiftsPerWeek",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MaxNightShiftsPerMonth",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MaxShiftsPerDay",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MaxConsecutiveNightShifts",
                table: "DepartmentSchedulingSettings");
            migrationBuilder.DropIndex(
                name: "IX_DepartmentSchedulingSettings_DepartmentId",
                table: "DepartmentSchedulingSettings");
        }
    }
}


