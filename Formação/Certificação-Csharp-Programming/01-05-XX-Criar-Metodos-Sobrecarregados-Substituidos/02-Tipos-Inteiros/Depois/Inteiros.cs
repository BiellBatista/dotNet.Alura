using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Depois
{
    class TiposInteiros : IAulaItem
    {
        public void Executar()
        {
            int idade = 15;
            //idade = 15.5; //não posso armazenar float em inteiro

            char resposta = 'S'; // System.Char

            byte niveldeAzul = 0xF; // = 255 em decimal 
            //nivelDeAzul = -3 //byte não permite numeros negativos

            short passageirosVoo = 230; // System.Int16
            passageirosVoo = -7;

            int populacao = 1500; // SystemInt.32
            populacao = -2300;

            long populacaoDoBrasil = 207_660_929; // +/- 207 milhões - System.Int64

            sbyte niveldeBrilho = -127; //System.SByte permite numeros negativos
            ushort passageirosNavio = 230; // System.UInt16 
            uint estoque = 1500; // System.UInt32
            ulong populacaoDoMundo = 7_000_000_000; //7 bilhões = System.UInt64

            Console.WriteLine($"resposta: {resposta}");

            Console.WriteLine($"nivelDeAzul: {niveldeAzul}");
            Console.WriteLine($"passageirosVoo: {passageirosVoo}");
            Console.WriteLine($"populacao: {populacao}");
            Console.WriteLine($"populacaoDoBrasil: {populacaoDoBrasil}");

            Console.WriteLine($"niveldeBrilho: {niveldeBrilho}");
            Console.WriteLine($"estoque: {estoque}");
            Console.WriteLine($"populacaoDoMundo: {populacaoDoMundo}");
        }
    }
}
