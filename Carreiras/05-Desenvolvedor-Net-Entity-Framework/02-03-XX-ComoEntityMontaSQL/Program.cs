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
    // mostrando os comando SQL geradospelo Entity
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new LojaContext())
            {
                //criando o serviço de provedor
                var serviceProvedor = contexto.GetInfrastructure<IServiceProvider>();
                //criando a fabrica de log
                var loggerFactory = serviceProvedor.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var produtos = contexto.Produtos.ToList();
                ExbieEntries(contexto.ChangeTracker.Entries());

                //var p1 = produtos.First();
                //contexto.Produtos.Remove(p1);
                //ExbieEntries(contexto.ChangeTracker.Entries()); //o primeiro produto recebe o estado "Deleted"
                //contexto.SaveChanges(); // após remover o produto do banco, ele irá sair da lista de Entries (entidade monitoradas)

                var novoProduto = new Produto()
                {
                    Nome = "Sabão em pó",
                    Categoria = "Limpeza",
                    Preco = 4.99
                };
                contexto.Produtos.Add(novoProduto);
                ExbieEntries(contexto.ChangeTracker.Entries());
                contexto.Produtos.Remove(novoProduto);
                /*
                 * Quando um objeto com estado added é removido, antes do SaveChanes(), o Entity, simplesmente, o remove de sua lista de monitoracao 
                 */
                ExbieEntries(contexto.ChangeTracker.Entries());
                //contexto.SaveChanges();

                var entry = contexto.Entry(novoProduto);
                Console.WriteLine("=================Não está na Lista====================");
                // isso mostra o estado "detached", significa que o objeto está desconectado da lista de estado, pois ele foi adicionado e removido sem o SaveChanges()
                // ou ele foi removido da lista unchagend e sofreu um saveChanges()
                Console.WriteLine(entry.Entity.ToString() + entry.State);
                /*
                 * Como o objeto já estava sendo monitorado pois o método Add() foi utilizado , ao utilizarmos o método Remove() ele vai para o estado de Detached diretamente, pois ele ainda não foi para o banco.
                 * 
                 * 
                 * Detached - Quando você remove um objeto do banco com o saveChanges, após ele estar no estado de Deleted ou quando você remove ele com o .Remove() da listas de objetos monitorados.
                 */
            }
        }

        private static void EstadoAdded()
        {
            using (var contexto = new LojaContext())
            {
                //criando o serviço de provedor
                var serviceProvedor = contexto.GetInfrastructure<IServiceProvider>();
                //criando a fabrica de log
                var loggerFactory = serviceProvedor.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var produtos = contexto.Produtos.ToList();
                ExbieEntries(contexto.ChangeTracker.Entries());

                var novoProduto = new Produto()
                {
                    Nome = "Desinfetante",
                    Categoria = "Limpeza",
                    Preco = 2.99
                };
                contexto.Produtos.Add(novoProduto);

                ExbieEntries(contexto.ChangeTracker.Entries()); //o produto recebe o estado "Added"

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
                Console.WriteLine(e.Entity.ToString() + e.State);
            }
        }
    }
}
//Console.WriteLine("=================");
//produtos = contexto.Produtos.ToList();
//foreach (var p in produtos)
//{
//    Console.WriteLine(p);
//}

//static void Main(string[] args)
//{
//    using (var contexto = new LojaContext())
//    {
//        // criando o serviço de provedor
//        var serviceProvedor = contexto.GetInfrastructure<IServiceProvider>();
//        // criando a fabrica de log
//        var loggerFactory = serviceProvedor.GetService<ILoggerFactory>();
//        loggerFactory.AddProvider(SqlLoggerProvider.Create());

//        var produtos = contexto.Produtos.ToList();
//        // pegando todos os livros
//        foreach (var item in produtos)
//        {
//            Console.WriteLine(item);
//        }

//        Console.WriteLine("Lista de entidades deste contexto");
//        // listando todas as entidades deste contexto
//        foreach (var item in contexto.ChangeTracker.Entries())
//        {
//            // listando cada entidade deste contexto
//            Console.WriteLine(item);
//            // listando o estado de cada entidade
//            Console.WriteLine(item.State);
//        }
//        Console.WriteLine("=============================");

//        var p1 = contexto.Produtos.Last();
//        p1.Nome = "Clube da Luta 02";

//        Console.WriteLine("Lista de entidades deste contexto");
//        // listando todas as entidades deste contexto
//        foreach (var item in contexto.ChangeTracker.Entries())
//        {
//            // listando cada entidade deste contexto
//            Console.WriteLine(item);
//            // listando o estado de cada entidade
//            Console.WriteLine(item.State);
//        }
//        Console.WriteLine("=============================");

//        //contexto.SaveChanges();
//        //Console.WriteLine("=============================");
//        //produtos = contexto.Produtos.ToList();
//        //// pegando todos os livros
//        //foreach (var item in produtos)
//        //{
//        //    Console.WriteLine(item);
//        //}
//    }
//}
//}
//}

/**
 * Como o Entity sabe que alterando um atributo do produto, ele deve altera daquele?
 * 
 * O contexto herda de DbContext (classe base de toda a API do Entity).
 * A clase DbContext possui o atributo objeto de "ChangeTrack" que é responsável por rastrear toda as modificações daquele contexto
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
