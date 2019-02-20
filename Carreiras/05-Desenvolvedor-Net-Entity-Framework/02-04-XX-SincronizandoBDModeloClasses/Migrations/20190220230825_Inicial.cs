using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _02_04_XX_SincronizandoBDModeloClasses.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // É necessário comentar todas as linhas desse método, pois o banco de dados está executando todas a migration, porque a tabela do histórico está vazia e ele irá começar pela migration mais nova. Se a migration mais nova estiver na tabela do histórico, o Entity irá para a próxima, sucessivamente
            // Após isso eu executo Update-Database Inicial (onde o Inicial é a migration especifica que quero colocar na table de histórico
            // depois eu posso descomentar
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categoria = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
            // após a execução desta migration, o nome dela vai para a tabela de histórico, pois assim o Entity não irá execuar ela quando for dado o comando Update-Database
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
