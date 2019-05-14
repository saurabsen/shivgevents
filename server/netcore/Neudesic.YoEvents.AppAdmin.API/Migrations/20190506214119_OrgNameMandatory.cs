using Microsoft.EntityFrameworkCore.Migrations;

namespace Neudesic.YoEvents.AppAdmin.API.Migrations
{
    public partial class OrgNameMandatory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "org",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "org",
                table: "Organizations",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
