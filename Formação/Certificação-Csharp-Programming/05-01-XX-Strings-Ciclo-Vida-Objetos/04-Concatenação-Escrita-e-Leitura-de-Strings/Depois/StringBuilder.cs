using System;
using System.Text;

namespace _05_01_XX_Strings_Ciclo_Vida_Objetos.Depois
{
    class StringBuilder1 : IAulaItem
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
