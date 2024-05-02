using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace master_bppm.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                columns: table => new
                {
                    LOG_MASTER_DATA_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BPPM_ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    TIME_STAMP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ORACLE_ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    ORGANIZATION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ORACLE_ITEM_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ORACLE_ITEM_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MACHINE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHOTO_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DETAILS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XXB7_ESS_BPPM_LOG_MASTER_DATA", x => x.LOG_MASTER_DATA_ID);
                });

            migrationBuilder.CreateTable(
                name: "XXB7_ESS_BPPM_MASTER_DATA",
                columns: table => new
                {
                    BPPM_ITEM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORACLE_ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    ORGANIZATION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ORACLE_ITEM_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ORACLE_ITEM_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MACHINE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHOTO_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DETAILS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UNIT_PRICE = table.Column<int>(type: "int", nullable: true),
                    AVAILABILITY = table.Column<int>(type: "int", nullable: true),
                    MIN_QTY = table.Column<int>(type: "int", nullable: true),
                    MAX_QTY = table.Column<int>(type: "int", nullable: true),
                    USAGE_PER_YEAR = table.Column<int>(type: "int", nullable: true),
                    STATUS = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XXB7_ESS_BPPM_MASTER_DATA", x => x.BPPM_ITEM_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XXB7_ESS_BPPM_LOG_MASTER_DATA");

            migrationBuilder.DropTable(
                name: "XXB7_ESS_BPPM_MASTER_DATA");
        }
    }
}
