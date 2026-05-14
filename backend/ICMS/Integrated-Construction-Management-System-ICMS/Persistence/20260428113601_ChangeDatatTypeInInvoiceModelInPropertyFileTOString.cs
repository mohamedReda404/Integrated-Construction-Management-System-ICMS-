using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrated_Construction_Management_System_ICMS.Persistence
{
    /// <inheritdoc />
    public partial class ChangeDatatTypeInInvoiceModelInPropertyFileTOString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BOQPricing");

            migrationBuilder.AlterColumn<string>(
                name: "File",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "File",
                table: "Invoice",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BOQPricing",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
