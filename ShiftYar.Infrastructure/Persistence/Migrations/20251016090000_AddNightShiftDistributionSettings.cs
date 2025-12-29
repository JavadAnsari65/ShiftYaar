using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftYar.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNightShiftDistributionSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnableNightShiftDistributionBySeniority",
                table: "DepartmentSchedulingSettings",
                type: "bit",
                nullable: true,
                comment: "فعال‌سازی توزیع شیفت‌های شب بر اساس سابقه");

            migrationBuilder.AddColumn<int>(
                name: "NightShiftDistributionType",
                table: "DepartmentSchedulingSettings",
                type: "int",
                nullable: true,
                comment: "نوع توزیع: 0=شب‌دوست (سابقه بیشتر اولویت), 1=شب‌گریز (سابقه کمتر اولویت), 2=خنثی");

            migrationBuilder.AddColumn<double>(
                name: "NightShiftDistributionWeight",
                table: "DepartmentSchedulingSettings",
                type: "float",
                nullable: true,
                comment: "وزن توزیع شیفت‌های شب بر اساس سابقه");


            migrationBuilder.AddColumn<double>(
                name: "SeniorityDistributionSlope",
                table: "DepartmentSchedulingSettings",
                type: "float",
                nullable: true,
                comment: "شیب توزیع بر اساس سابقه (مقدار پیش‌فرض: 1.0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnableNightShiftDistributionBySeniority",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "NightShiftDistributionType",
                table: "DepartmentSchedulingSettings");

            migrationBuilder.DropColumn(
                name: "NightShiftDistributionWeight",
                table: "DepartmentSchedulingSettings");


            migrationBuilder.DropColumn(
                name: "SeniorityDistributionSlope",
                table: "DepartmentSchedulingSettings");
        }
    }
}
