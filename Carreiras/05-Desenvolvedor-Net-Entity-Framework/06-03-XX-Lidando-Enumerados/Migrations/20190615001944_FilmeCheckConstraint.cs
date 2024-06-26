﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.Filmes.App.Migrations
{
    public partial class FilmeCheckConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"ALTER TABLE [dbo].[film]
                            ADD CONSTRAINT [check_rating] CHECK (
                                [rating]='NC-17' OR
                                [rating]='R' OR
                                [rating]='PG-13' OR
                                [rating]='PG' OR [rating]='G');";
            //adicionando um comando SQL na hora da realização da Migration. O comando será executado
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //se eu fasso um SQL no UP, devo fazer no DOWN
            //esse sql apaga a constraint
            var sql = @"ALTER TABLE [dbo].[film]
                            DROP CONSTRAINT [check_rating]";
            migrationBuilder.Sql(sql);
        }
    }
}
