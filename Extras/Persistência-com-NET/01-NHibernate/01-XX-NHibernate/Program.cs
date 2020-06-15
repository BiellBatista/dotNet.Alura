using _01_XX_NHibernate.Infra;
using System;

namespace _01_XX_NHibernate
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
