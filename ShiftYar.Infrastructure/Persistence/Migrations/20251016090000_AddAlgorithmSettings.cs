using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShiftYar.Infrastructure.Persistence.Migrations
{
    public partial class AddAlgorithmSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlgorithmSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AlgorithmType = table.Column<int>(type: "int", nullable: false),
                    SA_InitialTemperature = table.Column<double>(type: "float", nullable: true),
                    SA_FinalTemperature = table.Column<double>(type: "float", nullable: true),
                    SA_CoolingRate = table.Column<double>(type: "float", nullable: true),
                    SA_MaxIterations = table.Column<int>(type: "int", nullable: true),
                    SA_MaxIterationsWithoutImprovement = table.Column<int>(type: "int", nullable: true),
                    ORT_MaxTimeInSeconds = table.Column<int>(type: "int", nullable: true),
                    ORT_NumSearchWorkers = table.Column<int>(type: "int", nullable: true),
                    ORT_LogSearchProgress = table.Column<bool>(type: "bit", nullable: true),
                    ORT_MaxSolutions = table.Column<int>(type: "int", nullable: true),
                    ORT_RelativeGapLimit = table.Column<double>(type: "float", nullable: true),
                    HYB_Strategy = table.Column<int>(type: "int", nullable: true),
                    HYB_MaxIterations = table.Column<int>(type: "int", nullable: true),
                    HYB_ComplexityThreshold = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TheUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgorithmSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlgorithmSettings_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlgorithmSettings_DepartmentId_AlgorithmType",
                table: "AlgorithmSettings",
                columns: new[] { "DepartmentId", "AlgorithmType" },
                unique: true,
                filter: "[DepartmentId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlgorithmSettings");
        }
    }
}


