﻿using System;

namespace _05_02_XX_Coletando_Lixo.Antes
{
    class TiposDeValor : IAulaItem
    {
        public void Executar()
        {
            Metodo1();
            Console.ReadKey();
        }

        void Metodo1()
        {
            Metodo2(12);
            ///< image url="$(ProjectDir)\img1.png"/>
            Console.WriteLine("Saindo do método 1...");
        }

        void Metodo2(int dados)
        {
            int multiplicador = 2;
            Console.WriteLine("O valor é: " + dados.ToString());
            Metodo3(dados * multiplicador);
            ///< image url="$(ProjectDir)\img2.png"/>

            ///< image url="$(ProjectDir)\img4.png"/>
        }

        void Metodo3(int dados)
        {
            Console.WriteLine("O dobro é: " + dados.ToString());
            ///< image url="$(ProjectDir)\img3.png"/>
        }
    }
}
