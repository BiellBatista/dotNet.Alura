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
                        var contaCorrente = ConverterStringParaContaCorrente(linha);

                        Console.WriteLine($"Conta número {contaCorrente.Numero}, ag. {contaCorrente.Agencia}. Saldo: {contaCorrente.Saldo}");
                        //Console.WriteLine(linha);
                    }
                }
            }

            Console.ReadLine();
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            string[] campos = linha.Split(' '); //quebrando uma string a partir de um caracter
            /*
             * Gabriel de Almeida Batista
             * campo1  2  campo3  campo4
             */
            var agencia = campos[0];
            var numero = campos[1];
            var saldo = campos[2].Replace('.', ',');
            var nomeTitular = campos[3];

            var agenciaComoInt = int.Parse(agencia);
            var numeroComoInt = int.Parse(numero);
            var saldoComoDouble = double.Parse(saldo);

            var resultado = new ContaCorrente(agenciaComoInt, numeroComoInt);
            resultado.Depositar(saldoComoDouble);

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            resultado.Titular = titular;

            return resultado;
        }
    }
}