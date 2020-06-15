using _03_XX_NHibernate.DAO;
using _03_XX_NHibernate.Entidades;
using _03_XX_NHibernate.Infra;
using NHibernate;
using System;

namespace _03_XX_NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            //NHibernateHelper.GeraSchema();
            //gravando dados no banco

            //configuranto a sessão (conexão)
            //Configuration cfg = NHibernateHelper.RecuperaConfiguracao();
            //ISessionFactory sessionFactory = cfg.BuildSessionFactory();

            //abrindo a sessão (conexão)
            //ISession session = sessionFactory.OpenSession();

            //Usuario novoUsuario = new Usuario();
            //novoUsuario.Nome = "Gabriel";

            //abrindo uma transação
            //ITransaction transacao = session.BeginTransaction();
            //session.Save(novoUsuario);
            //commitando
            //transacao.Commit();
            //fechando a sessão (conexão)
            //session.Close();

            ISession session = NHibernateHelper.AbreSession();
            UsuarioDAO usuarioDao = new UsuarioDAO(session);

            Usuario novoUsuario = new Usuario();
            novoUsuario.Nome = "Diego";

            usuarioDao.Adiciona(novoUsuario);

            session.Close();

            Console.Read();
        }
    }
}
