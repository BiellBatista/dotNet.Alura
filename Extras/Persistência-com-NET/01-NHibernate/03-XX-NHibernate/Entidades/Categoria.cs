﻿using System.Collections.Generic;

namespace _03_XX_NHibernate.Entidades
{
    public class Categoria
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }

        public virtual IList<Produto> Produtos { get; set; }
    }
}
