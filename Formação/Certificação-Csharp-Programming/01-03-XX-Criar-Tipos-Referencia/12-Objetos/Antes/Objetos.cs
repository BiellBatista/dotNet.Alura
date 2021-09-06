using System;

namespace _01_03_XX_Criar_Tipos_Referencia.Antes
{
    internal class Objetos : IAulaItem
    {
        public void Executar()
        {
            int pontuacao = 10;
            Console.WriteLine($"pontuacao: {pontuacao}");
        }
    }

    internal class Jogador
    {
        public int Pontuacao { get; set; } = 10;
    }
}