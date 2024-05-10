using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRG.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class APRDRGtableupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.CreateTable(
                name: "APRDRGV36s",
                columns: table => new
                {
                    APRDRG = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    SOIScore = table.Column<int>(type: "int", nullable: false),
                    CombinedSOI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V36RelativeWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MLOS = table.Column<double>(type: "float", nullable: true),
                    DayOutlierThreshold = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APRDRGV36s", x => x.APRDRG);
                });

            migrationBuilder.CreateTable(
                name: "APRDRGV38s",
                columns: table => new
                {
                    APRDRG = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    SOIScore = table.Column<int>(type: "int", nullable: false),
                    CombinedSOI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V38RelativeWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MLOS = table.Column<double>(type: "float", nullable: true),
                    DayOutlierThreshold = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APRDRGV38s", x => x.APRDRG);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APRDRGV36s");

            migrationBuilder.DropTable(
                name: "APRDRGV38s");

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    APRDRG = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CombinedSOI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayOutlierThreshold = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    MLOS = table.Column<double>(type: "float", nullable: true),
                    SOIScore = table.Column<int>(type: "int", nullable: false),
                    V36RelativeWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    V38RelativeWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.APRDRG);
                });
        }
    }
}
