using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SavePoint.Data.Migrations
{
    public partial class Genre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Types",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "Types",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }
    }
}
