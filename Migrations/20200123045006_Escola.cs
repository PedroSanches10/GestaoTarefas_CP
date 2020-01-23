using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefas_CP.Migrations
{
    public partial class Escola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Escola_EscolaId",
                table: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Professor_EscolaId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "EscolaId",
                table: "Professor");

            migrationBuilder.AddColumn<string>(
                name: "Escola",
                table: "Professor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Escola",
                table: "Professor");

            migrationBuilder.AddColumn<int>(
                name: "EscolaId",
                table: "Professor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professor_EscolaId",
                table: "Professor",
                column: "EscolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Escola_EscolaId",
                table: "Professor",
                column: "EscolaId",
                principalTable: "Escola",
                principalColumn: "EscolaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
