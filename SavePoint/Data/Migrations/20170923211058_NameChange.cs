using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SavePoint.Data.Migrations
{
    public partial class NameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Console",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Games",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Games",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Consoles",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Types",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Consoles",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Types",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Games",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Games",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Console",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Games",
                nullable: true);
        }
    }
}
