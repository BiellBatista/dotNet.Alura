﻿using System;

namespace _04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.Intraestrutura.Binding
{
    public class ArgumentoNomeValor
    {


        public string Nome { get; private set; }
        public string Valor { get; private set; }

        public ArgumentoNomeValor(string nome, string valor)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Valor = valor ?? throw new ArgumentNullException(nameof(nome));
        }
    }
}
