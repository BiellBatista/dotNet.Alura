using Microsoft.EntityFrameworkCore;
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
        {// include == JOIN
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                // fazendo um select com relação 1:1. Com LEFT JOIN (lado Cliente)  
                var cliente = contexto
                    .Clientes
                    .Include(c => c.EnderecoEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"Endereço de entrega: {cliente.EnderecoEntrega.Logradouro}");

                // fazendo um select com 1:N
                var produtos = contexto
                    .Produtos
                    .Include(p => p.Compras)
                    .Where(p => p.Id == 3002)
                    .FirstOrDefault();

                Console.WriteLine($"Mostrando as Compras do Produto {produtos.Nome}");
                foreach(var item in produtos.Compras)
                    Console.WriteLine(item);
            }
        }

        private static void SelecaoNPraMComJoin()
        {
            using (var contexto2 = new LojaContext())
            {
                // o comportamento padrão dos ORM é não realizar JOINS quando for realizado um select, pois isso traria diversos objetos e prejudicaria a peformance
                // var promocao = contexto2.Promocoes.FirstOrDefault(); // realizando um select

                var promocao = contexto2
                    .Promocoes
                    .Include(p => p.Produtos) // incluindo uma nova tabela no JOIN
                    .ThenInclude(pp => pp.Produto) // adicionado uma clausula INNER JOIN
                    .FirstOrDefault();

                Console.WriteLine("\nMostrando os produtos da promoção...");
                foreach (var item in promocao.Produtos)
                    Console.WriteLine(item.Produto);
            }
        }

        private static void IncluirPromocao()
        {
            using (var contexto = new LojaContext())
            {
                //Logando o SQL
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());
                //
                var promocao = new Promocao();
                promocao.Descricao = "Queima Total Janeiro 2017";
                promocao.Inicio = new DateTime(2017, 1, 1);
                promocao.Termino = new DateTime(2017, 1, 31);

                var produtos = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Bebidas")
                    .ToList();

                foreach (var item in produtos)
                    promocao.IncluirProduto(item);

                contexto.Promocoes.Add(promocao);
                ExbieEntries(contexto.ChangeTracker.Entries());
                contexto.SaveChanges(); //fechando contexto
                // quando fecha um contexto, os objetos do ChangeTracker deixa de ser gerenciados
            }
        }

        private static void UmParaUm()
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
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

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

    ================================================

    var cliente = contexto.Clientes
  .Include(c => c.Contas)
  .FirstOrDefault();
 
Quase lá! Você incluiu apenas o relacionamento com a classe de join. Falta colocar mais um método, chamado ThenInclude, com argumento de entrada uma expressão lambda que retorne a propriedade Conta presente na classe ContaCliente.
=================================



O método Include possui uma segunda sobrecarga, que permite informarmos como argumento de entrada uma string com o nome da propriedade de navegação a ser incluída no join. A vantagem dessa abordagem é que não precisamos usar outros métodos ThenInclude para continuar a navegação em outras entidades. Por exemplo, para o exemplo Cliente x Conta, poderíamos fazer:

var lista = contexto.Clientes.Include("Contas.Conta");
A desvantagem é que se o nome da propriedade mudar, teremos que lembrar todos os lugares onde fizemos isso, porque não teremos ajuda do compilador.
*/
