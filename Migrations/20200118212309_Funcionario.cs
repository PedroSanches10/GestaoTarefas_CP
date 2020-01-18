using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefas_CP.Migrations
{
    public partial class Funcionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Escola",
                table: "Funcionario",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Escola",
                table: "Funcionario");
        }
    }
}
