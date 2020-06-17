using _08_XX_NHibernate.DAO;
using _08_XX_NHibernate.Entidades;
using _08_XX_NHibernate.Infra;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using System;
using System.Collections.Generic;

namespace _08_XX_NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            NHibernateHelper.GeraSchema();
            Console.Read();
        }
    }
}
