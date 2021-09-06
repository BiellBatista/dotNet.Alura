using System;

namespace _01_04_XX_Classes_Metodos_Extensao.Depois
{
    internal class Strings : IAulaItem
    {
        public void Executar()
        {
            string a = "bom dia";
            string b = "b";
            // Adiciona ao conteúdo de "b"
            b = b + "om dia";
            Console.WriteLine($"a == b: {a == b}"); //true
            Console.WriteLine($"(object)a == (object)b: {(object)a == (object)b}"); //false, porque neste caso estamos verificando se as variaveis
            //estão ocupando o mesmo ponto de referencia da memoria
            string bomDia = "bom dia";
            Console.WriteLine($"bomDia[4]: {bomDia[4]}");
            var caractere = bomDia[4];
            Console.WriteLine($"caractere.GetType(): {caractere.GetType()}");
        }
    }
}