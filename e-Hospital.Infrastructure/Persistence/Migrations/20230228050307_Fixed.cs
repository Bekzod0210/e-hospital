using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyMedicines_Orders_OrderId",
                table: "PharmacyMedicines");

            migrationBuilder.DropIndex(
                name: "IX_PharmacyMedicines_OrderId",
                table: "PharmacyMedicines");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "PharmacyMedicines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "PharmacyMedicines",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyMedicines_OrderId",
                table: "PharmacyMedicines",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyMedicines_Orders_OrderId",
                table: "PharmacyMedicines",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
