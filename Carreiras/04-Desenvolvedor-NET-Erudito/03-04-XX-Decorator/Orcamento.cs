﻿using System.Collections.Generic;

namespace _03_04_XX_Decorator
{
    public class Orcamento
    {
        public double Valor { get; private set; }
        public IList<Item> Itens { get; set; }

        public Orcamento(double valor)
        {
            Valor = valor;
            Itens = new List<Item>();
        }

        public void AdicionaItem(Item item)
        {
            Itens.Add(item);
        }
    }
}
