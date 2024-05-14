using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRG.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangingPKforHospitalRatesPt1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalRates",
                table: "HospitalRates");

            migrationBuilder.AlterColumn<string>(
                name: "NPI",
                table: "HospitalRates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalRates",
                table: "HospitalRates",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalRates",
                table: "HospitalRates");

            migrationBuilder.AlterColumn<string>(
                name: "NPI",
                table: "HospitalRates",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalRates",
                table: "HospitalRates",
                column: "NPI");
        }
    }
}
