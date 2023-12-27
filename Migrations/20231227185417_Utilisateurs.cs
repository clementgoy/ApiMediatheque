using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTodo.Migrations
{
    public partial class Utilisateurs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titre",
                table: "Documents",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Auteur",
                table: "Documents",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "UtilisateurId",
                table: "Documents",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Utilisateurs_UtilisateurId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Documents_UtilisateurId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "UtilisateurId",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "Titre",
                table: "Documents",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Auteur",
                table: "Documents",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
