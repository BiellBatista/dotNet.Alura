﻿using System;
using System.IO;
using System.Text;

namespace _08_04_XX_Gerenciando_Diretorios.Antes
{
    public class LerGravarStringsFluxosArquivos01 : IAulaItem
    {
        public void Executar()
        {
            // GRAVANDO UM ARQUIVO
            FileStream fluxoSaida = new FileStream("ArquivoSaida.txt", FileMode.Create, FileAccess.Write);
            string mensagemSaida = "Olá, Alura!";
            byte[] array = Encoding.UTF8.GetBytes(mensagemSaida);
            int posicao = 0;
            int tamanho = mensagemSaida.Length;

            fluxoSaida.Write(array, posicao, tamanho);
            fluxoSaida.Close();

            FileStream fluxoEntrada = new FileStream("ArquivoSaida.txt", FileMode.Open, FileAccess.Read);

            byte[] bytesLidos = new byte[fluxoEntrada.Length];

            fluxoEntrada.Read(bytesLidos, posicao, (int)fluxoEntrada.Length);

            string texto = Encoding.UTF8.GetString(bytesLidos);

            fluxoEntrada.Close();

            Console.WriteLine("Mensagem Lida: " + texto);
            Console.ReadKey();
        }
    }
}