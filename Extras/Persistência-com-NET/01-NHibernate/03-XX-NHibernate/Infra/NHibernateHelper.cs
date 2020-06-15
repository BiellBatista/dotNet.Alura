using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace _03_XX_NHibernate.Infra
{
    public class NHibernateHelper
    {
        public static ISessionFactory fabrica = CriaSessionFactory();

        public static ISessionFactory CriaSessionFactory()
        {
            Configuration cfg = RecuperaConfiguracao();
            return cfg.BuildSessionFactory();
        }

        public static Configuration RecuperaConfiguracao()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            return cfg;
        }

        public static void GeraSchema()
        {
            Configuration cfg = RecuperaConfiguracao();

            new SchemaExport(cfg).Create(true, true);
        }

        public static ISession AbreSession()
        {
            return fabrica.OpenSession();
        }
    }
}
