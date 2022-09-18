using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WNBA.Core.Api.Migrations
{
    public partial class fixTeamVenueDataFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsedSince",
                table: "TeamVenue");

            migrationBuilder.DropColumn(
                name: "UsedUntil",
                table: "TeamVenue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UsedSince",
                table: "TeamVenue",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UsedUntil",
                table: "TeamVenue",
                type: "datetime2",
                nullable: true);
        }
    }
}
