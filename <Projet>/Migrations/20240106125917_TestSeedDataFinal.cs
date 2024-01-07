using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTodo.Migrations
{
    public partial class TestSeedDataFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprunts_Documents_EmprunteId",
                table: "Emprunts");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprunts_Utilisateurs_EmprunteurId",
                table: "Emprunts");

            migrationBuilder.DropIndex(
                name: "IX_Emprunts_EmprunteId",
                table: "Emprunts");

            migrationBuilder.DropIndex(
                name: "IX_Emprunts_EmprunteurId",
                table: "Emprunts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Emprunts_EmprunteId",
                table: "Emprunts",
                column: "EmprunteId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprunts_EmprunteurId",
                table: "Emprunts",
                column: "EmprunteurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunts_Documents_EmprunteId",
                table: "Emprunts",
                column: "EmprunteId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunts_Utilisateurs_EmprunteurId",
                table: "Emprunts",
                column: "EmprunteurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
