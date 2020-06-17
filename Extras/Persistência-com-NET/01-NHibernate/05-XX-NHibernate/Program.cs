using _05_XX_NHibernate.DAO;
using _05_XX_NHibernate.Entidades;
using _05_XX_NHibernate.Infra;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using System;
using System.Collections.Generic;

namespace _05_XX_NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            ISession session = NHibernateHelper.AbreSession();

            //string hql = "from Produto";
            //string hql = "from Produto p order by p.Nome";
            // para declarar um parametro na minha consulta, uso o ?. A contagem começa no 0. Este é o método posicional
            //string hql = "from Produto p where p.Preco > ?";
            // parametro nomeado
            //string hql = "from Produto p where p.Preco > :minimo and p.Categoria.Name = :categoria";
            string hql = "select p.Categoria as Categoria, count(p) as NumeroDePedidos from Produto p group by p.Categoria";
            IQuery query = session.CreateQuery(hql);
            //query.SetParameter(0, 10); //falando que o parametro 0 será o 10
            //query.SetParameter("minimo", 10); //falando que o parametro "minimo" será o 10
            //query.SetParameter("categoria", "Uma categoria"); //falando que o parametro "categoria" será "Uma categoria"
            //IList<Produto> produtos = query.List<Produto>();

            query.SetResultTransformer(Transformers.AliasToBean<ProdutosPorCategoria>());
            IList<ProdutosPorCategoria> relatorio = query.List<ProdutosPorCategoria>();
            //foreach (var produto in produtos)
            //{
            //    Console.WriteLine(produto.Nome);
            //}

            session.Close();

            Console.Read();
        }
    }

    public class ProdutosPorCategoria
    {
        public Categoria Categoria { get; set; }
        public long NumeroDePedidos { get; set; }
    }
}
