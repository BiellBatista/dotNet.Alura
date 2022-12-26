using Microsoft.EntityFrameworkCore.Migrations;

namespace _01_XX_Integracao_Entrega_Continua_Azure_DevOps.Dados.Migrations
{
    public partial class Atualizacao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PixConta",
                table: "conta_corrente",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PixConta",
                table: "conta_corrente");
        }
    }
}