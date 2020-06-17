using _08_XX_NHibernate.Entidades;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;

namespace _08_XX_NHibernate.DAO
{
    public class ProdutoDAO
    {
        private ISession _session;

        public ProdutoDAO(ISession session)
        {
            _session = session;
        }

        public void Adiciona(Produto produto)
        {
            ITransaction transacao = _session.BeginTransaction();
            _session.Save(produto);
            transacao.Commit();
        }

        public void Apagar(Produto produto)
        {
            ITransaction transacao = _session.BeginTransaction();
            _session.Delete(produto);
            transacao.Commit();
        }

        public Produto BuscaPorId(int id)
        {
            return _session.Get<Produto>(id);
        }

        public IList<Produto> BuscaPorNomePrecoMinimoECategoria(string nome, decimal precoMinimo, string nomeCategoria)
        {
            // criando um critério para busca, porque alguns parametros podem ser nulos
            ICriteria criteria = _session.CreateCriteria<Produto>();

            if (!string.IsNullOrEmpty(nome))
            {
                criteria.Add(Restrictions.Eq("Nome", nome));
            }

            if(precoMinimo > 0)
            {
                criteria.Add(Restrictions.Ge("Preco", precoMinimo));
            }

            if (!string.IsNullOrEmpty(nomeCategoria))
            {
                // colocando um criterio onde o atributo a ser verificado faz parte de outra tabela (a tabela está ligada com o relacionamento) 
                ICriteria criteriaCategoria = criteria.CreateCriteria("Categoria");
                criteriaCategoria.Add(Restrictions.Eq("Nome", nomeCategoria));
            }

            return criteria.List<Produto>();
        }
    }
}
