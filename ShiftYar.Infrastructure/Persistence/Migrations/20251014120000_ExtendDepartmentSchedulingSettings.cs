using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftYar.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ExtendDepartmentSchedulingSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnforceMinimumShiftsForRotatingStaff",
                table: "DepartmentSchedulingSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinMorningShiftsForThreeShiftRotation",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinEveningShiftsForThreeShiftRotation",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinNightShiftsForThreeShiftRotation",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinFirstShiftForTwoShiftRotation",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinSecondShiftForTwoShiftRotation",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnableNightShiftPreference",
                table: "DepartmentSchedulingSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NightShiftPreferenceType",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NightShiftPreferenceWeight",
                table: "DepartmentSchedulingSettings",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequireExperiencedManagerForNightShift",
                table: "DepartmentSchedulingSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinExperienceYearsForNightShiftManager",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NightShiftManagerRequirementWeight",
                table: "DepartmentSchedulingSettings",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnableSpecialtyPriorityInShifts",
                table: "DepartmentSchedulingSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SpecialtyPriorityWeight",
                table: "DepartmentSchedulingSettings",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnableGenderBalancePerShiftType",
                table: "DepartmentSchedulingSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GenderBalancePerShiftWeight",
                table: "DepartmentSchedulingSettings",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnforceShiftTypeLimits",
                table: "DepartmentSchedulingSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinMorningShiftsPerMonth",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxMorningShiftsPerMonth",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinEveningShiftsPerMonth",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxEveningShiftsPerMonth",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinNightShiftsPerMonth",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxNightShiftsPerMonth",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnforceMinimumShiftsForRotatingStaff",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MinMorningShiftsForThreeShiftRotation",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MinEveningShiftsForThreeShiftRotation",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MinNightShiftsForThreeShiftRotation",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MinFirstShiftForTwoShiftRotation",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MinSecondShiftForTwoShiftRotation",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "EnableNightShiftPreference",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "NightShiftPreferenceType",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "NightShiftPreferenceWeight",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "RequireExperiencedManagerForNightShift",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MinExperienceYearsForNightShiftManager",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "NightShiftManagerRequirementWeight",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "EnableSpecialtyPriorityInShifts",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "SpecialtyPriorityWeight",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "EnableGenderBalancePerShiftType",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "GenderBalancePerShiftWeight",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "EnforceShiftTypeLimits",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MinMorningShiftsPerMonth",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MaxMorningShiftsPerMonth",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MinEveningShiftsPerMonth",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MaxEveningShiftsPerMonth",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MinNightShiftsPerMonth",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "MaxNightShiftsPerMonth",
                table: "DepartmentSchedulingSettings");
        }
    }
}
