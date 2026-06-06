using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrated_Construction_Management_System_ICMS.Presistence
{
    /// <inheritdoc />
    public partial class initrr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOQPricing_BOQ_BOQId",
                table: "BOQPricing");

            migrationBuilder.DropIndex(
                name: "IX_BOQPricing_BOQId",
                table: "BOQPricing");

            migrationBuilder.DropColumn(
                name: "BOQId",
                table: "BOQPricing");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BOQId",
                table: "BOQPricing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BOQPricing_BOQId",
                table: "BOQPricing",
                column: "BOQId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BOQPricing_BOQ_BOQId",
                table: "BOQPricing",
                column: "BOQId",
                principalTable: "BOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
