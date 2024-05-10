using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRG.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    APRDRG = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    SOIScore = table.Column<int>(type: "int", nullable: false),
                    CombinedSOI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V36RelativeWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    V38RelativeWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MLOS = table.Column<double>(type: "float", nullable: true),
                    DayOutlierThreshold = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.APRDRG);
                });

            migrationBuilder.CreateTable(
                name: "CHIRPHospitals",
                columns: table => new
                {
                    TIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    SDA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHIRPCLASS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NPI = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHIRPHospitals", x => x.TIN);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalNPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalPhysicalCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalPhysicalStreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIN = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.HospitalNPI);
                    table.ForeignKey(
                        name: "FK_Hospitals_CHIRPHospitals_TIN",
                        column: x => x.TIN,
                        principalTable: "CHIRPHospitals",
                        principalColumn: "TIN");
                });

            migrationBuilder.CreateTable(
                name: "HospitalRates",
                columns: table => new
                {
                    NPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    NPIMonthYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliverySDA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PPRPPC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contract = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PercentageThreshold = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HHSCPublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CHIRPRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CHIRP = table.Column<bool>(type: "bit", nullable: false),
                    HospitalNPI = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalRates", x => x.NPI);
                    table.ForeignKey(
                        name: "FK_HospitalRates_Hospitals_HospitalNPI",
                        column: x => x.HospitalNPI,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalNPI");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHIRPHospitals_NPI",
                table: "CHIRPHospitals",
                column: "NPI");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRates_HospitalNPI",
                table: "HospitalRates",
                column: "HospitalNPI");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_TIN",
                table: "Hospitals",
                column: "TIN");

            migrationBuilder.AddForeignKey(
                name: "FK_CHIRPHospitals_Hospitals_NPI",
                table: "CHIRPHospitals",
                column: "NPI",
                principalTable: "Hospitals",
                principalColumn: "HospitalNPI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CHIRPHospitals_Hospitals_NPI",
                table: "CHIRPHospitals");

            migrationBuilder.DropTable(
                name: "HospitalRates");

            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "CHIRPHospitals");
        }
    }
}
