using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftYar.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentSchedulingSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentSchedulingSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    ForbidUnavailableDates = table.Column<bool>(type: "bit", nullable: true),
                    ForbidDuplicateDailyAssignments = table.Column<bool>(type: "bit", nullable: true),
                    EnforceMaxShiftsPerDay = table.Column<bool>(type: "bit", nullable: true),
                    EnforceMinRestDays = table.Column<bool>(type: "bit", nullable: true),
                    EnforceMaxConsecutiveShifts = table.Column<bool>(type: "bit", nullable: true),
                    EnforceWeeklyMaxShifts = table.Column<bool>(type: "bit", nullable: true),
                    EnforceNightShiftMonthlyCap = table.Column<bool>(type: "bit", nullable: true),
                    EnforceSpecialtyCapacity = table.Column<bool>(type: "bit", nullable: true),
                    GenderBalanceWeight = table.Column<double>(type: "float", nullable: true),
                    SpecialtyPreferenceWeight = table.Column<double>(type: "float", nullable: true),
                    UserUnwantedShiftWeight = table.Column<double>(type: "float", nullable: true),
                    UserPreferredShiftWeight = table.Column<double>(type: "float", nullable: true),
                    WeeklyMaxWeight = table.Column<double>(type: "float", nullable: true),
                    MonthlyNightCapWeight = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TheUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSchedulingSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentSchedulingSettings_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSchedulingSettings_DepartmentId",
                table: "DepartmentSchedulingSettings",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentSchedulingSettings");
        }
    }
}
