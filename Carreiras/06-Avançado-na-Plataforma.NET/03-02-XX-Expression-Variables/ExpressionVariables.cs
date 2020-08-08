using System;

namespace _03_02_XX_Expression_Variables
{
    class AplicacaoWeb
    {
        public static string Porta = "8080";
        //campo expression variables
        public static bool EstaRodandoEmPortaAlta = int.TryParse(Porta, out int portaComoInt) && portaComoInt > 1024;
    }

    class ExpressionVariables
    {
        public static void TestaExpressionVariables()
        {
            var idadeComoTexto = "15";

            if (int.TryParse(idadeComoTexto, out int idade) && idade > 18)
            {
                Console.WriteLine("Você pode entrar");
            }
        }

        public static bool ValidaIdade(string idadeComoTexto) => int.TryParse(idadeComoTexto, out int idade) && idade > 18;
    }
}
