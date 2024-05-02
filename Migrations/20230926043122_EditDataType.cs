using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace master_bppm.Migrations
{
    /// <inheritdoc />
    public partial class EditDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "USER",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UOM",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "VARCHAR(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ORGANIZATION",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "VARCHAR(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ORACLE_ITEM_DESCRIPTION",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "VARCHAR(240)",
                maxLength: 240,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ORACLE_ITEM_CODE",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "VARCHAR(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MACHINE",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LOCATION",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DETAILS",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "USER",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "UOM",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ORGANIZATION",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "ORACLE_ITEM_DESCRIPTION",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(240)",
                oldMaxLength: 240,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ORACLE_ITEM_CODE",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MACHINE",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LOCATION",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DETAILS",
                table: "XXB7_ESS_BPPM_LOG_MASTER_DATA",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
