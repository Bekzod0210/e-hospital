using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace e_Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Patient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExaminationResults_Queues_QueueId",
                table: "MedicalExaminationResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Queues_Users_UserId",
                table: "Queues");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Queues",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Queues_UserId",
                table: "Queues",
                newName: "IX_Queues_PatientId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_PatientId");

            migrationBuilder.AlterColumn<int>(
                name: "QueueId",
                table: "MedicalExaminationResults",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MedicalExaminationResults",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "MedicalExaminationResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    MedicalExamationId = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExaminationResults_Patients_Id",
                table: "MedicalExaminationResults",
                column: "Id",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExaminationResults_Queues_QueueId",
                table: "MedicalExaminationResults",
                column: "QueueId",
                principalTable: "Queues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Patients_PatientId",
                table: "Orders",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Queues_Patients_PatientId",
                table: "Queues",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExaminationResults_Patients_Id",
                table: "MedicalExaminationResults");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExaminationResults_Queues_QueueId",
                table: "MedicalExaminationResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Patients_PatientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Queues_Patients_PatientId",
                table: "Queues");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "MedicalExaminationResults");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Queues",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Queues_PatientId",
                table: "Queues",
                newName: "IX_Queues_UserId");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PatientId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "QueueId",
                table: "MedicalExaminationResults",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MedicalExaminationResults",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExaminationResults_Queues_QueueId",
                table: "MedicalExaminationResults",
                column: "QueueId",
                principalTable: "Queues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Queues_Users_UserId",
                table: "Queues",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
