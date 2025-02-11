﻿using _09_XX_XX_EntradaSaídaStreams.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_XX_XX_EntradaSaídaStreams
{
    /**
     * Esta classe faz parte da class Program, com o modificado partial é possível dividir uma classe em dois arquivos
     */
    partial class Program
    {
        static void LidandoComFileStreamDiretamente()
        {
            var enderecoDoArquivo = "contas.txt";
            //var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open); //indicando o abrindo e falando o modo de operação
            //var buffer = new byte[1024]; //1Kb
            //var numeroDeBytesLidos = -1;

            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; //1Kb
                var numeroDeBytesLidos = -1;

                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                }
            }
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = new UTF8Encoding(); //criando o tranformador de byte

            //var texto = utf8.GetString(buffer);
            var texto = utf8.GetString(buffer, 0, bytesLidos); //Encoding irá processar os poucos bytes lidos. Tente aplicar isso no chatbot

            Console.Write(texto);

            foreach (var meuByte in buffer)
            {
                Console.Write(meuByte);
                Console.Write(" ");
            }
        }
    }
}
