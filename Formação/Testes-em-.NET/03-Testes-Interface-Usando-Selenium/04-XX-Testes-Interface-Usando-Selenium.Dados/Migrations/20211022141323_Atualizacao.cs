﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace _04_XX_Testes_Interface_Usando_Selenium.Dados.Migrations
{
    public partial class Atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Identificador",
                table: "conta_corrente",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Identificador",
                table: "cliente",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Identificador",
                table: "agencia",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identificador",
                table: "conta_corrente");

            migrationBuilder.DropColumn(
                name: "Identificador",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "Identificador",
                table: "agencia");
        }
    }
}