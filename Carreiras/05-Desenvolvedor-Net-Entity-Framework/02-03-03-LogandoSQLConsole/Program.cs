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
                // criando o serviço de provedor
                var serviceProvedor = contexto.GetInfrastructure<IServiceProvider>();
                // criando a fabrica de log
                var loggerFactory = serviceProvedor.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var produtos = contexto.Produtos.ToList();
                // pegando todos os livros
                foreach (var item in produtos)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Lista de entidades deste contexto");
                // listando todas as entidades deste contexto
                foreach (var item in contexto.ChangeTracker.Entries())
                {
                    // listando cada entidade deste contexto
                    Console.WriteLine(item);
                    // listando o estado de cada entidade
                    Console.WriteLine(item.State);
                }
                Console.WriteLine("=============================");

                var p1 = contexto.Produtos.Last();
                p1.Nome = "Clube da Luta 02";

                Console.WriteLine("Lista de entidades deste contexto");
                // listando todas as entidades deste contexto
                foreach (var item in contexto.ChangeTracker.Entries())
                {
                    // listando cada entidade deste contexto
                    Console.WriteLine(item);
                    // listando o estado de cada entidade
                    Console.WriteLine(item.State);
                }
                Console.WriteLine("=============================");

                //contexto.SaveChanges();
                //Console.WriteLine("=============================");
                //produtos = contexto.Produtos.ToList();
                //// pegando todos os livros
                //foreach (var item in produtos)
                //{
                //    Console.WriteLine(item);
                //}
            }
        }
    }
}

/**
 * Como o Entity sabe que alterando um atributo do produto, ele deve altera daquele?
 * 
 * O contexto herda de DbContext (classe base de toda a API do Entity).
 * A clase DbContext possui o atributo objeto de "ChangeTrack" que é responsável por rastrear toda as modificações daquele contexto
 */
