using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WNBA.Core.Api.Migrations
{
    public partial class AddEndedOnToTeamPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Season",
                table: "TeamCoaches");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndedOn",
                table: "TeamPlayers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndedOn",
                table: "TeamPlayers");

            migrationBuilder.AddColumn<int>(
                name: "Season",
                table: "TeamCoaches",
                type: "int",
                nullable: true);
        }
    }
}
