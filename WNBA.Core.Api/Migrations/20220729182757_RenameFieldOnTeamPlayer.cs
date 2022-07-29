using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WNBA.Core.Api.Migrations
{
    public partial class RenameFieldOnTeamPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "TeamPlayers",
                newName: "JerseyNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JerseyNumber",
                table: "TeamPlayers",
                newName: "Number");
        }
    }
}
