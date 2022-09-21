using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WNBA.Core.Api.Migrations
{
    public partial class addsPlayerStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamPlayerSeasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamesPlayed = table.Column<int>(type: "int", nullable: true),
                    GamesStarted = table.Column<int>(type: "int", nullable: true),
                    Minutes = table.Column<int>(type: "int", nullable: false),
                    FieldGoalsMade = table.Column<int>(type: "int", nullable: false),
                    FieldGoalsAttempts = table.Column<int>(type: "int", nullable: false),
                    FieldGoalsPercent = table.Column<int>(type: "int", nullable: false),
                    TwoPointsMade = table.Column<int>(type: "int", nullable: false),
                    TwoPointsAttempts = table.Column<int>(type: "int", nullable: false),
                    TwoPointsPercent = table.Column<int>(type: "int", nullable: false),
                    ThreePointsMade = table.Column<int>(type: "int", nullable: false),
                    ThreePointsAttempts = table.Column<int>(type: "int", nullable: false),
                    ThreePointsPercent = table.Column<int>(type: "int", nullable: false),
                    BlockedAttempts = table.Column<int>(type: "int", nullable: false),
                    FreeThrowsMade = table.Column<int>(type: "int", nullable: false),
                    FreeThrowsAttempts = table.Column<int>(type: "int", nullable: false),
                    FreeTrhowsPercent = table.Column<int>(type: "int", nullable: false),
                    OffensiveRebounds = table.Column<int>(type: "int", nullable: true),
                    OffRebounds = table.Column<int>(type: "int", nullable: true),
                    DefensiveRebounds = table.Column<int>(type: "int", nullable: true),
                    DefRebounds = table.Column<int>(type: "int", nullable: true),
                    Rebounds = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Turnovers = table.Column<int>(type: "int", nullable: false),
                    AssistsTurnoverRatio = table.Column<float>(type: "real", nullable: false),
                    Steals = table.Column<int>(type: "int", nullable: false),
                    Blocks = table.Column<int>(type: "int", nullable: false),
                    PersonalFouls = table.Column<int>(type: "int", nullable: false),
                    TechnicalFouls = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    FlagrantFouls = table.Column<int>(type: "int", nullable: false),
                    Ejections = table.Column<int>(type: "int", nullable: false),
                    Foulouts = table.Column<int>(type: "int", nullable: false),
                    TrueShootingAttempts = table.Column<float>(type: "real", nullable: false),
                    TrueShootingPercent = table.Column<float>(type: "real", nullable: false),
                    Efficiency = table.Column<int>(type: "int", nullable: false),
                    PointsOffTurnovers = table.Column<int>(type: "int", nullable: false),
                    PointsInPaint = table.Column<int>(type: "int", nullable: false),
                    PointsInPaintMade = table.Column<double>(type: "float", nullable: false),
                    PointsInPaintAttempts = table.Column<double>(type: "float", nullable: false),
                    PointsInPaintPercent = table.Column<double>(type: "float", nullable: false),
                    EffeciveFGPercent = table.Column<double>(type: "float", nullable: false),
                    DoubleDoubles = table.Column<int>(type: "int", nullable: false),
                    TripleDoubles = table.Column<int>(type: "int", nullable: false),
                    FoulsDrawn = table.Column<int>(type: "int", nullable: false),
                    OffensiveFouls = table.Column<int>(type: "int", nullable: false),
                    FastBreakPoints = table.Column<int>(type: "int", nullable: false),
                    FastBreakAttempts = table.Column<int>(type: "int", nullable: false),
                    FastBreakMade = table.Column<int>(type: "int", nullable: false),
                    FastBreakPercent = table.Column<int>(type: "int", nullable: false),
                    CoachEjections = table.Column<int>(type: "int", nullable: false),
                    SecondChancePercent = table.Column<int>(type: "int", nullable: false),
                    SecondChancePoints = table.Column<int>(type: "int", nullable: false),
                    SecondChanceAttributes = table.Column<int>(type: "int", nullable: false),
                    SecondChanceMade = table.Column<int>(type: "int", nullable: false),
                    Minus = table.Column<int>(type: "int", nullable: false),
                    Plus = table.Column<int>(type: "int", nullable: false),
                    CoachTechsFouls = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStats_TeamPlayerSeasons_TeamPlayerSeasonId",
                        column: x => x.TeamPlayerSeasonId,
                        principalTable: "TeamPlayerSeasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_TeamPlayerSeasonId",
                table: "PlayerStats",
                column: "TeamPlayerSeasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerStats");
        }
    }
}
