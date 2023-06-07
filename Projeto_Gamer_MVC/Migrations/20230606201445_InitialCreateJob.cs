using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Gamer_MVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "senha",
                table: "Jogador",
                newName: "Senha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Jogador",
                newName: "senha");
        }
    }
}
