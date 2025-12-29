using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftYar.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddShiftManagerSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequireManagerForMorningShift",
                table: "DepartmentSchedulingSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequireManagerForEveningShift",
                table: "DepartmentSchedulingSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequireManagerForNightShift",
                table: "DepartmentSchedulingSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ShiftManagerRequirementWeight",
                table: "DepartmentSchedulingSettings",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequireManagerForMorningShift",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "RequireManagerForEveningShift",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "RequireManagerForNightShift",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "ShiftManagerRequirementWeight",
                table: "DepartmentSchedulingSettings");
        }
    }
}
