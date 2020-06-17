using _07_XX_NHibernate.DAO;
using _07_XX_NHibernate.Entidades;
using _07_XX_NHibernate.Infra;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using System;
using System.Collections.Generic;

namespace _07_XX_NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            ISession session = NHibernateHelper.AbreSession();

            ProdutoDAO produtoDAO = new ProdutoDAO(session);
            IList<Produto> produtos = produtoDAO.BuscaPorNomePrecoMinimoECategoria("", 20, "");

            foreach (var produto in produtos)
            {
                Console.WriteLine("Nome: " + produto.Nome + " Preco: " + produto.Preco.ToString() + " Categoria: " + produto.Categoria.Nome);
            }

            session.Close();

            Console.Read();
        }
    }
}
