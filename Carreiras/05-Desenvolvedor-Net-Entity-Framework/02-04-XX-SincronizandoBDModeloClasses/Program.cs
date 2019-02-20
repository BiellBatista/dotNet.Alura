using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

/*
 * Add-Migration Registrar uma versão (migration, nos termos do Entity).
    Remove-Migration Esse comando é utilizado para remover a última migração não aplicada no banco de dados apontado pelo contexto.
    Update-Database Atualiza o banco de dados com base na tabela de histórico de migração
    Script-Migration Gera um script DDL para que seja executado no banco de dados
    Drop-Database Esse comando é utilizado para dropar o banco de dados apontado pelo contexto.
    Scaffold-DbContext Esse comando é utilizado para criar uma classe que estende de DbContext, além de classes que representam as tabelas do banco.

A migração é feita em dois passos. O primeiro passo é executarmos o comando Add-Migration.

Já o segundo passo pode ser feitas de duas maneiras diferentes, sendo a primeira gerando um script de linguagem DDL com o comando Script-Migration. Esse cenário é mais utilizado quando existe uma equipe de banco de dados separada da equipe de desenvolvimento.

A outra maneira é usarmos o comando Update-Database, onde o Entity pega a nova versão que foi registrada e executa diretamente no banco de dados. Vamos utilizar essa segunda forma.
 */
