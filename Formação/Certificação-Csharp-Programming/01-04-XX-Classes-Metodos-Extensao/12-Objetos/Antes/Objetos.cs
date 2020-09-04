using System;

namespace _01_04_XX_Classes_Metodos_Extensao.Antes
{
    class Objetos : IAulaItem
    {
        public void Executar()
        {
           int pontuacao = 10;
           Console.WriteLine($"pontuacao: {pontuacao}");
        }
    }

    class Jogador
    {
        public int Pontuacao { get; set; } = 10;
    }
}
