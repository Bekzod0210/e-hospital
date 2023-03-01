using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace e_Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExaminationResults_Patients_Id",
                table: "MedicalExaminationResults");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MedicalExaminationResults",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExaminationResults_PatientId",
                table: "MedicalExaminationResults",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExaminationResults_Patients_PatientId",
                table: "MedicalExaminationResults",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExaminationResults_Patients_PatientId",
                table: "MedicalExaminationResults");

            migrationBuilder.DropIndex(
                name: "IX_MedicalExaminationResults_PatientId",
                table: "MedicalExaminationResults");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MedicalExaminationResults",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExaminationResults_Patients_Id",
                table: "MedicalExaminationResults",
                column: "Id",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
