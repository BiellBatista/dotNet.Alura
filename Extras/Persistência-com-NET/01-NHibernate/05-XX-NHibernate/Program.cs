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
            // falando para o NHibernate trazer a categoria do produto. Devo fazer isso, porque o NHibernate faz consulta lazzy
            // ele busca os produtos e depois as categoria, não os dois ao mesmo tempo
            // devo usar o distict para não vim valores repetidos
            IQuery query = session.CreateQuery("from Produto p join fetch p.Categoria");
            IList<Produto> produtos = query.List<Produto>();

            foreach (var produto in produtos)
            {
                // sem o join fetch, o NHibernate procuraria a categoria para cada produto
                // ou seja, para cada produto, ele iria dar um select.. COm o join fetch eu resolvo isso, porque
                // ele vem com as categorias
                Console.WriteLine(produto.Nome + " - " + produto.Categoria.Nome);
            }

            session.Close();

            Console.Read();
        }
    }
}
