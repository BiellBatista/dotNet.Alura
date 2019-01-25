using _09_XX_XX_EntradaSaídaStreams.Modelos;
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
        static void Main(string[] args)
        {
            //LidandoComFileStreamDiretamente(); //Este método está em outro arquivo, mas ambos são a classe Program

            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                using (var leitor = new StreamReader(fluxoDeArquivo))
                { //leitor do arquivo, devo passar o fluxo que será analisado
                  //var linha = leitor.ReadToEnd(); //leia até o fim
                  //var linha = leitor.Read(); //leia o primeiro byte

                    while (!leitor.EndOfStream)
                    {
                        var linha = leitor.ReadLine(); //leia linha por linha
                        Console.WriteLine(linha);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}