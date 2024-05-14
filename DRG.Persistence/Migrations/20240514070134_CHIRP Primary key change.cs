using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRG.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CHIRPPrimarykeychange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_CHIRPHospitals_TIN",
                table: "Hospitals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CHIRPHospitals",
                table: "CHIRPHospitals");

            migrationBuilder.AlterColumn<string>(
                name: "TIN",
                table: "CHIRPHospitals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CHIRPNPI",
                table: "CHIRPHospitals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CHIRPHospitals",
                table: "CHIRPHospitals",
                column: "CHIRPNPI");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_CHIRPHospitals_TIN",
                table: "Hospitals",
                column: "TIN",
                principalTable: "CHIRPHospitals",
                principalColumn: "CHIRPNPI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_CHIRPHospitals_TIN",
                table: "Hospitals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CHIRPHospitals",
                table: "CHIRPHospitals");

            migrationBuilder.DropColumn(
                name: "CHIRPNPI",
                table: "CHIRPHospitals");

            migrationBuilder.AlterColumn<string>(
                name: "TIN",
                table: "CHIRPHospitals",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CHIRPHospitals",
                table: "CHIRPHospitals",
                column: "TIN");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_CHIRPHospitals_TIN",
                table: "Hospitals",
                column: "TIN",
                principalTable: "CHIRPHospitals",
                principalColumn: "TIN");
        }
    }
}
