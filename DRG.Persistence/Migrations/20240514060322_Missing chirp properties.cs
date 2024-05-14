using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRG.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Missingchirpproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalACIA",
                table: "CHIRPHospitals",
                newName: "UHRIPOP");

            migrationBuilder.RenameColumn(
                name: "OP",
                table: "CHIRPHospitals",
                newName: "UHRIPIP");

            migrationBuilder.RenameColumn(
                name: "IP",
                table: "CHIRPHospitals",
                newName: "TotalCHIRPOP");

            migrationBuilder.AddColumn<decimal>(
                name: "DHPContractRateIP",
                table: "CHIRPHospitals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DHPContractRateIPBH",
                table: "CHIRPHospitals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DHPContractRateOP",
                table: "CHIRPHospitals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCHIRIP",
                table: "CHIRPHospitals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DHPContractRateIP",
                table: "CHIRPHospitals");

            migrationBuilder.DropColumn(
                name: "DHPContractRateIPBH",
                table: "CHIRPHospitals");

            migrationBuilder.DropColumn(
                name: "DHPContractRateOP",
                table: "CHIRPHospitals");

            migrationBuilder.DropColumn(
                name: "TotalCHIRIP",
                table: "CHIRPHospitals");

            migrationBuilder.RenameColumn(
                name: "UHRIPOP",
                table: "CHIRPHospitals",
                newName: "TotalACIA");

            migrationBuilder.RenameColumn(
                name: "UHRIPIP",
                table: "CHIRPHospitals",
                newName: "OP");

            migrationBuilder.RenameColumn(
                name: "TotalCHIRPOP",
                table: "CHIRPHospitals",
                newName: "IP");
        }
    }
}
