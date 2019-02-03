using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_05_XX_ListaLigadaPilhaFila
{
    internal class Navegador
    {
        private readonly Stack<string> _historicoAnterior = new Stack<string>();
        private readonly Stack<string> _historicoProximo = new Stack<string>();

        private string _atual = "vazia";

        public Navegador()
        {
            System.Console.WriteLine($"Página atual: {_atual}");
        }

        internal void NavegarPara(string url)
        {
            //adicionando na pilha
            _historicoAnterior.Push(_atual);

            _atual = url;
            Console.WriteLine($"Página atual: {_atual}");
        }

        internal void Proximo()
        {
            if (_historicoProximo.Any())
            {
                _historicoAnterior.Push(_atual);
                _atual = _historicoProximo.Pop();
                Console.WriteLine($"Página atual: {_atual}");
            }
        }

        internal void Anterior()
        {
            if (_historicoAnterior.Any())
            {
                _historicoProximo.Push(_atual);
                _atual = _historicoAnterior.Pop(); //pegando o primeiro elemento da pilha
                Console.WriteLine($"Página atual: {_atual}");
            }
        }
    }
}