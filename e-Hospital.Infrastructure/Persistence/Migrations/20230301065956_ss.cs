using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MedicalExamationId",
                table: "Patients",
                newName: "MedicalExaminationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MedicalExaminationId",
                table: "Patients",
                newName: "MedicalExamationId");
        }
    }
}
