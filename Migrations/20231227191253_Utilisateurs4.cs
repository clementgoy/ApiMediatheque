using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTodo.Migrations
{
    public partial class Utilisateurs4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Utilisateurs_UtilisateurId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_UtilisateurId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "UtilisateurId",
                table: "Documents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UtilisateurId",
                table: "Documents",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UtilisateurId",
                table: "Documents",
                column: "UtilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Utilisateurs_UtilisateurId",
                table: "Documents",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id");
        }
    }
}
