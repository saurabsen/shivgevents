using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Neudesic.YoEvents.EventManagement.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "eventmgmt");

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "eventmgmt",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 5, 6, 22, 19, 18, 674, DateTimeKind.Utc).AddTicks(439)),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2019, 5, 6, 22, 19, 18, 676, DateTimeKind.Utc).AddTicks(8119)),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                schema: "eventmgmt",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events",
                schema: "eventmgmt");

            migrationBuilder.DropTable(
                name: "EventTypes",
                schema: "eventmgmt");
        }
    }
}
