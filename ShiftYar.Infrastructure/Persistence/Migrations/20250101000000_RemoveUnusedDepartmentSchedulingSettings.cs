using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftYar.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedDepartmentSchedulingSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // حذف فقط فیلدهای واقعاً غیرضروری از جدول DepartmentSchedulingSettings
            migrationBuilder.DropColumn(
                name: "ForbidUnavailableDates",
                table: "DepartmentSchedulingSettings");

            // حذف تنظیمات پیچیده و غیرضروری
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
                name: "RequireManagerForMorningShift",
                table: "DepartmentSchedulingSettings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // بازگردانی فیلدهای حذف شده (در صورت نیاز به rollback)
            migrationBuilder.AddColumn<bool>(
                name: "ForbidUnavailableDates",
                table: "DepartmentSchedulingSettings",
                type: "bit",
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

            migrationBuilder.AddColumn<bool>(
                name: "RequireManagerForMorningShift",
                table: "DepartmentSchedulingSettings",
                type: "bit",
                nullable: true);
        }
    }
}
