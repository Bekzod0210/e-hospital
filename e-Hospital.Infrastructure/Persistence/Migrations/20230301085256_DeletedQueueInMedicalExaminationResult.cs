using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeletedQueueInMedicalExaminationResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExaminationResults_Queues_QueueId",
                table: "MedicalExaminationResults");

            migrationBuilder.DropIndex(
                name: "IX_MedicalExaminationResults_QueueId",
                table: "MedicalExaminationResults");

            migrationBuilder.DropColumn(
                name: "QueueId",
                table: "MedicalExaminationResults");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QueueId",
                table: "MedicalExaminationResults",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExaminationResults_QueueId",
                table: "MedicalExaminationResults",
                column: "QueueId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExaminationResults_Queues_QueueId",
                table: "MedicalExaminationResults",
                column: "QueueId",
                principalTable: "Queues",
                principalColumn: "Id");
        }
    }
}
