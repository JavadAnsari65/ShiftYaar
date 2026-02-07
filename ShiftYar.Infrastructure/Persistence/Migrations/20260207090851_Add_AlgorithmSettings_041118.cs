using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftYar.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_AlgorithmSettings_041118 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ////migrationBuilder.AddColumn<bool>(
            ////    name: "EnableNightShiftDistributionBySeniority",
            ////    table: "DepartmentSchedulingSettings",
            ////    type: "bit",
            ////    nullable: true);

            //migrationBuilder.Sql(@"
            //    IF COL_LENGTH('dbo.DepartmentSchedulingSettings', 'EnableNightShiftDistributionBySeniority') IS NULL
            //    BEGIN
            //        ALTER TABLE dbo.DepartmentSchedulingSettings
            //        ADD EnableNightShiftDistributionBySeniority bit NULL;
            //    END
            //    ");

            ////migrationBuilder.AddColumn<bool>(
            ////    name: "EnableNightShiftPreference",
            ////    table: "DepartmentSchedulingSettings",
            ////    type: "bit",
            ////    nullable: true);

            //migrationBuilder.Sql(@"
            //    IF COL_LENGTH('dbo.DepartmentSchedulingSettings', 'EnableNightShiftPreference') IS NULL
            //    BEGIN
            //        ALTER TABLE dbo.DepartmentSchedulingSettings
            //        ADD EnableNightShiftPreference bit NULL;
            //    END
            //    ");

            ////migrationBuilder.AddColumn<bool>(
            ////    name: "EnforceMinimumShiftsForRotatingStaff",
            ////    table: "DepartmentSchedulingSettings",
            ////    type: "bit",
            ////    nullable: true);

            //migrationBuilder.Sql(@"
            //    IF COL_LENGTH('dbo.DepartmentSchedulingSettings', 'EnforceMinimumShiftsForRotatingStaff') IS NULL
            //    BEGIN
            //        ALTER TABLE dbo.DepartmentSchedulingSettings
            //        ADD EnforceMinimumShiftsForRotatingStaff bit NULL;
            //    END
            //    ");

            //migrationBuilder.AddColumn<double>(
            //    name: "ExtraShiftRotationWeight",
            //    table: "DepartmentSchedulingSettings",
            //    type: "float",
            //    nullable: true);

            //migrationBuilder.AddColumn<double>(
            //    name: "FairShiftCountBalanceWeight",
            //    table: "DepartmentSchedulingSettings",
            //    type: "float",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "FairnessLookbackMonths",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "MaxConsecutiveNightShifts",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "MaxConsecutiveShifts",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "MaxNightShiftsPerMonth",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "MaxShiftsPerDay",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "MaxShiftsPerWeek",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "MinEveningShiftsForThreeShiftRotation",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "MinFirstShiftForTwoShiftRotation",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "MinMorningShiftsForThreeShiftRotation",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "MinNightShiftsForThreeShiftRotation",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "MinRestDaysBetweenShifts",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "MinSecondShiftForTwoShiftRotation",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "NightShiftDistributionType",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<double>(
            //    name: "NightShiftDistributionWeight",
            //    table: "DepartmentSchedulingSettings",
            //    type: "float",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "NightShiftPreferenceType",
            //    table: "DepartmentSchedulingSettings",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<double>(
            //    name: "NightShiftPreferenceWeight",
            //    table: "DepartmentSchedulingSettings",
            //    type: "float",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "RequireManagerForEveningShift",
            //    table: "DepartmentSchedulingSettings",
            //    type: "bit",
            //    nullable: true);

            //migrationBuilder.AddColumn<double>(
            //    name: "SeniorityDistributionSlope",
            //    table: "DepartmentSchedulingSettings",
            //    type: "float",
            //    nullable: true);

            //migrationBuilder.AddColumn<double>(
            //    name: "ShiftLabelBalanceWeight",
            //    table: "DepartmentSchedulingSettings",
            //    type: "float",
            //    nullable: true);

            //migrationBuilder.AddColumn<double>(
            //    name: "ShiftManagerRequirementWeight",
            //    table: "DepartmentSchedulingSettings",
            //    type: "float",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "AlgorithmSettings",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DepartmentId = table.Column<int>(type: "int", nullable: true),
            //        AlgorithmType = table.Column<int>(type: "int", nullable: false),
            //        SA_InitialTemperature = table.Column<double>(type: "float", nullable: true),
            //        SA_FinalTemperature = table.Column<double>(type: "float", nullable: true),
            //        SA_CoolingRate = table.Column<double>(type: "float", nullable: true),
            //        SA_MaxIterations = table.Column<int>(type: "int", nullable: true),
            //        SA_MaxIterationsWithoutImprovement = table.Column<int>(type: "int", nullable: true),
            //        ORT_MaxTimeInSeconds = table.Column<int>(type: "int", nullable: true),
            //        ORT_NumSearchWorkers = table.Column<int>(type: "int", nullable: true),
            //        ORT_LogSearchProgress = table.Column<bool>(type: "bit", nullable: true),
            //        ORT_MaxSolutions = table.Column<int>(type: "int", nullable: true),
            //        ORT_RelativeGapLimit = table.Column<double>(type: "float", nullable: true),
            //        HYB_Strategy = table.Column<int>(type: "int", nullable: true),
            //        HYB_MaxIterations = table.Column<int>(type: "int", nullable: true),
            //        HYB_ComplexityThreshold = table.Column<double>(type: "float", nullable: true),
            //        CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        TheUserId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AlgorithmSettings", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AlgorithmSettings_Departments_DepartmentId",
            //            column: x => x.DepartmentId,
            //            principalTable: "Departments",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ShiftExchanges",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RequestingUserId = table.Column<int>(type: "int", nullable: true),
            //        OfferingUserId = table.Column<int>(type: "int", nullable: true),
            //        RequestingShiftAssignmentId = table.Column<int>(type: "int", nullable: true),
            //        OfferingShiftAssignmentId = table.Column<int>(type: "int", nullable: true),
            //        Status = table.Column<int>(type: "int", nullable: true),
            //        RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SupervisorId = table.Column<int>(type: "int", nullable: true),
            //        SupervisorComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        ExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        TheUserId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ShiftExchanges", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ShiftExchanges_ShiftAssignments_OfferingShiftAssignmentId",
            //            column: x => x.OfferingShiftAssignmentId,
            //            principalTable: "ShiftAssignments",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_ShiftExchanges_ShiftAssignments_RequestingShiftAssignmentId",
            //            column: x => x.RequestingShiftAssignmentId,
            //            principalTable: "ShiftAssignments",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_ShiftExchanges_Users_OfferingUserId",
            //            column: x => x.OfferingUserId,
            //            principalTable: "Users",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_ShiftExchanges_Users_RequestingUserId",
            //            column: x => x.RequestingUserId,
            //            principalTable: "Users",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_ShiftExchanges_Users_SupervisorId",
            //            column: x => x.SupervisorId,
            //            principalTable: "Users",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AlgorithmSettings_DepartmentId",
            //    table: "AlgorithmSettings",
            //    column: "DepartmentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ShiftExchanges_OfferingShiftAssignmentId",
            //    table: "ShiftExchanges",
            //    column: "OfferingShiftAssignmentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ShiftExchanges_OfferingUserId",
            //    table: "ShiftExchanges",
            //    column: "OfferingUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ShiftExchanges_RequestingShiftAssignmentId",
            //    table: "ShiftExchanges",
            //    column: "RequestingShiftAssignmentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ShiftExchanges_RequestingUserId",
            //    table: "ShiftExchanges",
            //    column: "RequestingUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ShiftExchanges_SupervisorId",
            //    table: "ShiftExchanges",
            //    column: "SupervisorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AlgorithmSettings");

            //migrationBuilder.DropTable(
            //    name: "ShiftExchanges");

            //migrationBuilder.DropColumn(
            //    name: "EnableNightShiftDistributionBySeniority",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "EnableNightShiftPreference",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "EnforceMinimumShiftsForRotatingStaff",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "ExtraShiftRotationWeight",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "FairShiftCountBalanceWeight",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "FairnessLookbackMonths",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "MaxConsecutiveNightShifts",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "MaxConsecutiveShifts",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "MaxNightShiftsPerMonth",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "MaxShiftsPerDay",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "MaxShiftsPerWeek",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "MinEveningShiftsForThreeShiftRotation",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "MinFirstShiftForTwoShiftRotation",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "MinMorningShiftsForThreeShiftRotation",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "MinNightShiftsForThreeShiftRotation",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "MinRestDaysBetweenShifts",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "MinSecondShiftForTwoShiftRotation",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "NightShiftDistributionType",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "NightShiftDistributionWeight",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "NightShiftPreferenceType",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "NightShiftPreferenceWeight",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "RequireManagerForEveningShift",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "SeniorityDistributionSlope",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "ShiftLabelBalanceWeight",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.DropColumn(
            //    name: "ShiftManagerRequirementWeight",
            //    table: "DepartmentSchedulingSettings");

            //migrationBuilder.RenameColumn(
            //    name: "RequireManagerForNightShift",
            //    table: "DepartmentSchedulingSettings",
            //    newName: "ForbidUnavailableDates");
        }
    }
}
