using _04_XX_NHibernate.DAO;
using _04_XX_NHibernate.Entidades;
using _04_XX_NHibernate.Infra;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;

namespace _04_XX_NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Categoria umaCategoria = new Categoria();
            //umaCategoria.Nome = "Uma Categoria";

            //Produto novoProduto = new Produto();
            //novoProduto.Nome = "Camiseta";
            //novoProduto.Preco = 10;
            //novoProduto.Categoria = umaCategoria;

            //ISession session = NHibernateHelper.AbreSession();
            //ITransaction transacao = session.BeginTransaction();

            //session.Save(umaCategoria);
            //session.Save(novoProduto);
            //transacao.Commit();
            //session.Close();

            ISession session = NHibernateHelper.AbreSession();
            ITransaction transacao = session.BeginTransaction();

            Categoria categoria = session.Load<Categoria>(1);
            IList<Produto> produtos = categoria.Produtos;

            transacao.Commit();
            session.Close();

            produtos.ForEach(p => Console.WriteLine($"{p.Nome} - {p.Categoria.Nome}"));

            Console.Read();
        }
    }
}
