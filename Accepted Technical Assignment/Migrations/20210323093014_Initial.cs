using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accepted_Technical_Assignment.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    MatchDate = table.Column<DateTime>(type: "date", nullable: true),
                    MatchTime = table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    TeamA = table.Column<string>(maxLength: 100, nullable: true),
                    TeamB = table.Column<string>(maxLength: 100, nullable: true),
                    Sport = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MatchOdds",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(nullable: true),
                    Specifier = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Odd = table.Column<decimal>(type: "decimal(5, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchOdds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MatchOdds_Match",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchOdds_MatchId",
                table: "MatchOdds",
                column: "MatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchOdds");

            migrationBuilder.DropTable(
                name: "Match");
        }
    }
}
