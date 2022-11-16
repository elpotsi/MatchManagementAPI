using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchManagementAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    MatchDate = table.Column<DateTime>(nullable: false),
                    MatchTime = table.Column<TimeSpan>(nullable: false),
                    TeamA = table.Column<string>(maxLength: 250, nullable: false),
                    TeamB = table.Column<string>(maxLength: 250, nullable: false),
                    Sport = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
