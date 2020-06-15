using _04_XX_NHibernate.Entidades;
using NHibernate;

namespace _04_XX_NHibernate.DAO
{
    public class UsuarioDAO
    {
        private ISession _session;

        public UsuarioDAO(ISession session)
        {
            _session = session;
        }

        public void Adiciona(Usuario usuario)
        {
            ITransaction transacao = _session.BeginTransaction();
            _session.Save(usuario);
            transacao.Commit();
        }

        public void Apagar(Usuario usuario)
        {
            ITransaction transacao = _session.BeginTransaction();
            _session.Delete(usuario);
            transacao.Commit();
        }

        public Usuario BuscaPorId(int id)
        {
            return _session.Get<Usuario>(id);
        }
    }
}
