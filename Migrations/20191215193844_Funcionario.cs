using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefas_CP.Migrations
{
    public partial class Funcionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Funcionario = table.Column<string>(nullable: true),
                    Numero_Funcionario = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true),
                    CodPostal = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telemovel = table.Column<string>(nullable: true),
                    NIF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
