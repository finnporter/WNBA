using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WNBA.Core.Api.Migrations
{
    public partial class updatePlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Players",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Players",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BirthDate",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DraftedBy",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "DraftedYear",
                table: "Players",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HeightInCm",
                table: "Players",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HeightInINches",
                table: "Players",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HighSchool",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JerseyNumber",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pick",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "RookieYear",
                table: "Players",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Round",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WeightInKg",
                table: "Players",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WeightInPounds",
                table: "Players",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DraftedBy",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DraftedYear",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "HeightInCm",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "HeightInINches",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "HighSchool",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "JerseyNumber",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Pick",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RookieYear",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Round",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "WeightInKg",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "WeightInPounds",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Players",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Players",
                newName: "Country");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
