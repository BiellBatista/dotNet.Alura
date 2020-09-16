using System;
using System.IO;

namespace _04_06_XX_Excecoes_SQL_Server_Rede.Depois
{
    public class LeitorDeArquivo6 : IDisposable
    {
        public string Arquivo { get; }

        public LeitorDeArquivo6(string arquivo)
        {
            Arquivo = arquivo;

            // throw new FileNotFoundException();

            Console.WriteLine("Abrindo arquivo: " + arquivo);
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha. . .");

            throw new IOException();

            return "Linha do arquivo";
        }

        public void Dispose()
        {
            Console.WriteLine("Fechando arquivo.");
        }
    }
}
