﻿using _04_06_XX_Bridges.Interpreter;
using System;

namespace _04_06_XX_Bridges.Visitor
{
    public class Impressora : IVisitor
    {
        public void ImprimeSoma(Soma soma)
        {
            Console.Write("(");
            soma.Esquerda.Aceita(this);
            Console.Write(" + ");
            soma.Direita.Aceita(this);
            Console.Write(")");
        }

        public void ImprimeSubtracao(Subtracao subtracao)
        {
            Console.Write("(");
            subtracao.Esquerda.Aceita(this);
            Console.Write(" - ");
            subtracao.Direita.Aceita(this);
            Console.Write(")");
        }

        public void ImprimeNumero(Numero numero)
        {
            Console.Write(numero.Valor);
        }
    }
}
