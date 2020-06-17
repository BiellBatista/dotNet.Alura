using System.Collections.Generic;

namespace _08_XX_NHibernate.Entidades
{
    public class Venda
    {
        public virtual int Id { get; set; }
        public virtual Usuario Cliente { get; set; }
        public virtual IList<Produto> Produtos { get; set; }

        public Venda()
        {
            Produtos = new List<Produto>();
        }
    }
}
