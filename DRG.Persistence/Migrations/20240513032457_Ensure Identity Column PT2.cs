using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRG.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EnsureIdentityColumnPT2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Hospitals",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HospitalRates",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CHIRPHospitals",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HospitalRates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CHIRPHospitals");
        }
    }
}
