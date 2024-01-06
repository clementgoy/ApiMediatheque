using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTodo.Migrations
{
    public partial class NomDeLaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateEmprunt",
                table: "Emprunts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEmprunt",
                table: "Emprunts");
        }
    }
}
