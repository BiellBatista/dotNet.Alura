using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Antes
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
