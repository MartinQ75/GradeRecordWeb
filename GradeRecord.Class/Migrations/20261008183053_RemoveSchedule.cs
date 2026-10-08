using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeRecord.Class.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_SubjectId = table.Column<int>(type: "int", nullable: false),
                    Classroom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Id_Teacher_Subject = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Teachers_Subjects_Teacher_SubjectId",
                        column: x => x.Teacher_SubjectId,
                        principalTable: "Teachers_Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Teacher_SubjectId",
                table: "Schedules",
                column: "Teacher_SubjectId");
        }
    }
}
