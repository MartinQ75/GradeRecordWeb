using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeRecord.Class.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Teachers_Subjects_Teacher_SubjectId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_Groups_GroupId",
                table: "Students_Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_Students_StudentId",
                table: "Students_Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_Groups_GroupId",
                table: "Teachers_Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_Subjects_SubjectId",
                table: "Teachers_Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_Teachers_TeacherId",
                table: "Teachers_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_Subjects_GroupId",
                table: "Teachers_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_Subjects_SubjectId",
                table: "Teachers_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_Subjects_TeacherId",
                table: "Teachers_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Students_Groups_GroupId",
                table: "Students_Groups");

            migrationBuilder.DropIndex(
                name: "IX_Students_Groups_StudentId",
                table: "Students_Groups");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_Teacher_SubjectId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Teachers_Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Teachers_Subjects");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Teachers_Subjects");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Students_Groups");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Students_Groups");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Teacher_SubjectId",
                table: "Grades");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Subjects_Id_Group",
                table: "Teachers_Subjects",
                column: "Id_Group");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Subjects_Id_Subject",
                table: "Teachers_Subjects",
                column: "Id_Subject");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Subjects_Id_Teacher",
                table: "Teachers_Subjects",
                column: "Id_Teacher");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Groups_Id_Group",
                table: "Students_Groups",
                column: "Id_Group");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Groups_Id_Student",
                table: "Students_Groups",
                column: "Id_Student");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Id_Student",
                table: "Grades",
                column: "Id_Student");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Id_Teacher_Subject",
                table: "Grades",
                column: "Id_Teacher_Subject");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_Id_Student",
                table: "Grades",
                column: "Id_Student",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Teachers_Subjects_Id_Teacher_Subject",
                table: "Grades",
                column: "Id_Teacher_Subject",
                principalTable: "Teachers_Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_Groups_Id_Group",
                table: "Students_Groups",
                column: "Id_Group",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_Students_Id_Student",
                table: "Students_Groups",
                column: "Id_Student",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_Groups_Id_Group",
                table: "Teachers_Subjects",
                column: "Id_Group",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_Subjects_Id_Subject",
                table: "Teachers_Subjects",
                column: "Id_Subject",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_Teachers_Id_Teacher",
                table: "Teachers_Subjects",
                column: "Id_Teacher",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_Id_Student",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Teachers_Subjects_Id_Teacher_Subject",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_Groups_Id_Group",
                table: "Students_Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_Students_Id_Student",
                table: "Students_Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_Groups_Id_Group",
                table: "Teachers_Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_Subjects_Id_Subject",
                table: "Teachers_Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_Teachers_Id_Teacher",
                table: "Teachers_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_Subjects_Id_Group",
                table: "Teachers_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_Subjects_Id_Subject",
                table: "Teachers_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_Subjects_Id_Teacher",
                table: "Teachers_Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Students_Groups_Id_Group",
                table: "Students_Groups");

            migrationBuilder.DropIndex(
                name: "IX_Students_Groups_Id_Student",
                table: "Students_Groups");

            migrationBuilder.DropIndex(
                name: "IX_Grades_Id_Student",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_Id_Teacher_Subject",
                table: "Grades");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Teachers_Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Teachers_Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Teachers_Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Students_Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Students_Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Teacher_SubjectId",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Subjects_GroupId",
                table: "Teachers_Subjects",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Subjects_SubjectId",
                table: "Teachers_Subjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Subjects_TeacherId",
                table: "Teachers_Subjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Groups_GroupId",
                table: "Students_Groups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Groups_StudentId",
                table: "Students_Groups",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Teacher_SubjectId",
                table: "Grades",
                column: "Teacher_SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Teachers_Subjects_Teacher_SubjectId",
                table: "Grades",
                column: "Teacher_SubjectId",
                principalTable: "Teachers_Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_Groups_GroupId",
                table: "Students_Groups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_Students_StudentId",
                table: "Students_Groups",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_Groups_GroupId",
                table: "Teachers_Subjects",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_Subjects_SubjectId",
                table: "Teachers_Subjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_Teachers_TeacherId",
                table: "Teachers_Subjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
