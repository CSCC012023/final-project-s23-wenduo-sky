using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yourscope_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStudentProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_CoverLetters_CoverLetterResumeId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_CoverLetterResumeId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "CoverLetterResumeId",
                table: "Experiences");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoverLetterResumeId",
                table: "Experiences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_CoverLetterResumeId",
                table: "Experiences",
                column: "CoverLetterResumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_CoverLetters_CoverLetterResumeId",
                table: "Experiences",
                column: "CoverLetterResumeId",
                principalTable: "CoverLetters",
                principalColumn: "ResumeId");
        }
    }
}
