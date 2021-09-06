using System;
using System.Text;

namespace _05_06_XX_Formatacao_Strings.Depois
{
    internal class StringBuilder1 : IAulaItem
    {
        public void Executar()
        {
            StringBuilder materias = new StringBuilder();
            materias.Append("Português");
            Console.WriteLine(materias);
            materias.Append(", Matemática");
            Console.WriteLine(materias);
            materias.Append(", Geografia");
            Console.WriteLine(materias);
            Console.ReadKey();

            ///<image url="$(ProjectDir)/img1.png"/>
        }
    }
}