using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho de Tal";
            fulano.EnderecoEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua dos Inválidos",
                Complemento = "sobrado",
                Bairro = "Centro",
                Cidade = "Cidade"
            };

            using (var contexto = new LojaContext())
            {
                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
        }

        private static void MuitosParaMuitos()
        {
            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Marcarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas" };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.Inicio = DateTime.Now;
            promocaoDePascoa.Termino = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluirProduto(p1);
            promocaoDePascoa.IncluirProduto(p2);
            promocaoDePascoa.IncluirProduto(p3);

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                //contexto.Promocoes.Add(promocaoDePascoa);
                var promocao = contexto.Promocoes.Find(1);
                contexto.Promocoes.Remove(promocao);
                ExbieEntries(contexto.ChangeTracker.Entries());
                contexto.SaveChanges();
                ExbieEntries(contexto.ChangeTracker.Entries());
            }
        }

        private static void UmParaMuitos()
        {
            // compra de 6 pães frances
            var paoFrances = new Produto();
            paoFrances.Nome = "Pão Franês";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidade";
            paoFrances.Categoria = "Padaria";

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Compras.Add(compra); // estado Added (equivalente ao insert)
                ExbieEntries(contexto.ChangeTracker.Entries());
                contexto.SaveChanges();
                ExbieEntries(contexto.ChangeTracker.Entries());
            }
        }

        private static void ExbieEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("=================");
            foreach (var e in entries)
            {
                // mostrando o estado do objeto
                Console.WriteLine(e.Entity.ToString() + " " + e.State);
            }
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

/*
* Added
O objeto é novo, foi adicionado ao contexto, e o método SaveChanges ainda não foi executado. Depois que as mudanças são feitas, o estado do objeto muda para Unchanged. Objetos no estado Added não têm seus valores rastreados em sua instância de EntityEntry.

Deleted
O objeto foi excluído do contexto. Depois que as mudanças foram salvas, seu estado muda para Detached.

Detached
O objeto existe, mas não está sendo monitorado. Uma entidade fica nesse estado imediatamente após ter sido criada e antes de ser adicionada ao contexto. Ela também fica nesse estado depois que foi removida do contexto através do método Detach ou se é carregada por um método com opção NoTracking. Não existem instâncias de EntityEntry associadas a objetos com esse estado.

Modified
Uma das propriedades escalares do objeto foi modificada e o método SaveChanges ainda não foi executado. Quando o monitoramento automático de mudanças está desligado, o estado é alterado para Modified apenas quando o método DetectChanges é chamado. Quando as mudanças são salvas, o estado do objeto muda para Unchanged.

Unchanged
O objeto não foi modificado desde que foi anexado ao contexto ou desde a última vez que o método SaveChanges foi chamado.
*/
