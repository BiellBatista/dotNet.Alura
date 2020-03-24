using Microsoft.EntityFrameworkCore.Migrations;

namespace _04_05_XX_CasaDoCodigo.Migrations
{
    public partial class Pedido_ClienteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClienteId",
                table: "Pedido",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pedido");
        }
    }
}
