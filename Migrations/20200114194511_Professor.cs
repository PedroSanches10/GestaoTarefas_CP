using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefas_CP.Migrations
{
    public partial class Professor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Funcionario");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Funcionario",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionario",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NIF",
                table: "Funcionario",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Morada",
                table: "Funcionario",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Funcionario",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    CargoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Cargo = table.Column<string>(nullable: true),
                    Escola_Cargo = table.Column<string>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.CargoId);
                    table.ForeignKey(
                        name: "FK_Cargo_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    Telemovel = table.Column<string>(maxLength: 9, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Gabinete = table.Column<string>(maxLength: 3, nullable: false),
                    Disciplina = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_FuncionarioId",
                table: "Cargo",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "NIF",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Morada",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
