﻿using System;
using System.Threading.Tasks;

namespace _05_02_XX_Coletando_Lixo.Antes
{
    internal class TiposDeReferencia : IAulaItem
    {
        public async void Executar()
        {
            await Task.Delay(3000); //aguarda 3 segundos

            GerarTiposValor();

            Console.ReadKey();
        }

        private static void GerarTiposValor()
        {
            for (long i = 0; i < 100000; i++)
            {
                EstruturaLivro livro = new EstruturaLivro
                {
                    NumeroPaginas = 1200
                };
            }
        }

        private static void GerarTiposReferencia()
        {
            for (long i = 0; i < 100000; i++)
            {
                ClasseLivro livro = new ClasseLivro
                {
                    Introducao = new string(' ', 100000),
                    Texto = new string(' ', 100000),
                    Conclusao = new string(' ', 100000)
                };
            }
        }
    }

    internal struct EstruturaLivro
    {
        public double NumeroPaginas { get; set; }
    }

    internal class ClasseLivro
    {
        public string Introducao { get; set; }
        public string Texto { get; set; }
        public string Conclusao { get; set; }
    }
}