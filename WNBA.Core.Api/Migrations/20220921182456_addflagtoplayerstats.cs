using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WNBA.Core.Api.Migrations
{
    public partial class addflagtoplayerstats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTotal",
                table: "PlayerStats",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTotal",
                table: "PlayerStats");
        }
    }
}
