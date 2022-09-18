using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WNBA.Core.Api.Migrations
{
    public partial class AddCoachPlayerUpdateTeamPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundedOn",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "JerseyNumber",
                table: "TeamPlayers");

            migrationBuilder.DropColumn(
                name: "JoinedOn",
                table: "TeamPlayers");

            migrationBuilder.DropColumn(
                name: "LeftOn",
                table: "TeamPlayers");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Teams",
                newName: "Market");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Teams",
                newName: "Alias");

            migrationBuilder.AddColumn<DateTime>(
                name: "Founded",
                table: "Teams",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamCoaches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCoaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamCoaches_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamCoaches_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamCoaches_CoachId",
                table: "TeamCoaches",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCoaches_TeamId",
                table: "TeamCoaches",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamCoaches");

            migrationBuilder.DropColumn(
                name: "Founded",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "Market",
                table: "Teams",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Alias",
                table: "Teams",
                newName: "City");

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundedOn",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "JerseyNumber",
                table: "TeamPlayers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedOn",
                table: "TeamPlayers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LeftOn",
                table: "TeamPlayers",
                type: "datetime2",
                nullable: true);
        }
    }
}
