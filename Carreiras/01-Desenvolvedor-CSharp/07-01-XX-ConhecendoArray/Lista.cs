using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_01_XX_ConhecendoArray
{
    public class Lista<T>
    {

        private T[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public Lista(int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(T item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

            //Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        public void ArgumentosNomeados(string texto = "sdhuahusadhusda", int numero = 6)
        {

        }

        public void Remover(T item)
        {
            int indiceItem = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                T itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao; i++)
                _itens[i] = _itens[i + 1];
            _proximaPosicao--;
            //não tem como colocar null, porque null não é um valor e sim uma referência
            //_itens[_proximaPosicao] = null;
        }

        //public void EscreverListaNaTela()
        //{
        //    for (int i = 0; i < _proximaPosicao; i++)
        //    {
        //        object conta = _itens[i];
        //        Console.WriteLine($"Conta no índice {i}: número {conta.Agencia} {conta.Numero}");
        //    }
        //}

        public T GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
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

            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            //Console.WriteLine("Aumentando capacidade da lista!");

            T[] novoArray = new T[novoTamanho];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
                //Console.WriteLine(".");
            }

            _itens = novoArray;
        }

        //a palavra params serve para determinar a entrada de N argumentos e serve para qualquer tipo
        public void AdicionarVarios(params T[] itens)
        {
            foreach (T i in itens)
                Adicionar(i);
        }

        //public void AdicionarVarios(ContaCorrente[] itens)
        //{
        //    foreach (ContaCorrente i in itens)
        //        Adicionar(i);
        //}

        // isso se chama indexador
        public T this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }
    }
}
