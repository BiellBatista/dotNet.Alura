﻿using System;

namespace _05_06_XX_Extraindo_Incorporando_Classe_Refatoracao.R08.ReplaceMethodWithMethodObject.antes
{
    class Produto
    {
        private readonly string descricao;
        private bool promocional;
        private readonly decimal precoBase;
        private readonly decimal acrescimo;
        private readonly decimal desconto;

        public string Descricao { get => descricao; }
        public bool Promocional { get => promocional; }
        public decimal PrecoBase { get => precoBase; }
        public decimal Acrescimo { get => acrescimo; }
        public decimal Desconto { get => desconto; }

        public Produto(string descricao, decimal precoBase, decimal acrescimo, decimal desconto)
        {
            this.descricao = descricao;
            this.precoBase = precoBase;
            this.acrescimo = acrescimo;
            this.desconto = desconto;

            var preco = Preco(precoBase, acrescimo, desconto);

            Console.WriteLine($"ANTES: O preço é {preco}");
        }

        decimal Preco(decimal precoBase, decimal acrescimo, decimal desconto)
        {
            var resultado = precoBase;

            if (this.promocional && desconto > 0)
            {
                throw new Exception("Produto já é promocional e não pode ter desconto!");
            }

            if (desconto > 20)
            {
                desconto = 20;
            }

            if (acrescimo > 15)
            {
                acrescimo = 15;
            }

            return precoBase + precoBase * (acrescimo - desconto);
        }

        public void HabilitarPromocao()
        {
            if (desconto == 0)
            {
                this.promocional = true;
            }
            else
            {
                throw new Exception("Produto com desconto não pode ser transformado em produto promocional!");
            }
        }
    }
}
