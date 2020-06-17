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
            ISession session2 = NHibernateHelper.AbreSession();

            // cacheado as query para diminuir as idas e vindas do banco de dados
            //Categoria c = session.Get<Categoria>(1);
            //Categoria c2 = session2.Get<Categoria>(1);

            //Console.WriteLine(c.Produtos.Count);
            //Console.WriteLine(c2.Produtos.Count);

            //salvando so resultados de uma query
            session.CreateQuery("from Usuario").SetCacheable(true).List<Usuario>();
            session2.CreateQuery("from Usuario").SetCacheable(true).List<Usuario>();

            session.Close();
            Console.Read();
        }
    }
}
