using _05_XX_XX_BibliotecasDLLs.Modelos;
using System;

namespace _07_01_XX_ConhecendoArray
{
    public class ListaDeContaCorrente
    {
        private ContaCorrente[] _itens;
        private int _proximaPosicao;

        public int Tamanho {
            get
            {
                return _proximaPosicao;
            }
        }

        public ListaDeContaCorrente(int capacidadeInicial = 5)
        {
            _itens = new ContaCorrente[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(ContaCorrente item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        public void ArgumentosNomeados(string texto = "sdhuahusadhusda", int numero = 6)
        {

        }

        public void Remover(ContaCorrente item)
        {
            int indiceItem = -1;

            for(int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            for(int i = indiceItem; i < _proximaPosicao; i++)
                _itens[i] = _itens[i + 1];
            _proximaPosicao--;
        }

        public void EscreverListaNaTela()
        {
            for(int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente conta = _itens[i];
                Console.WriteLine($"Conta no índice {i}: número {conta.Agencia} {conta.Numero}");
            }
        }

        public ContaCorrente GetContaCorrente(int indice)
        {
            if (indice < 0)
                throw new ArgumentOutOfRangeException(nameof(indice));
            return _itens[indice];
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;

            if(novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            Console.WriteLine("Aumentando capacidade da lista!");

            ContaCorrente[] novoArray = new ContaCorrente[novoTamanho];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
                Console.WriteLine(".");
            }
        }

        //a palavra params serve para determinar a entrada de N argumentos e serve para qualquer tipo
        public void AdicionarVarios(params ContaCorrente[] itens)
        {
            foreach (ContaCorrente i in itens)
                Adicionar(i);
        }

        //public void AdicionarVarios(ContaCorrente[] itens)
        //{
        //    foreach (ContaCorrente i in itens)
        //        Adicionar(i);
        //}

        // isso se chama indexador
        public ContaCorrente this[int indice]
        {
            get
            {
                return GetContaCorrente(indice);
            }
        }
    }
}
