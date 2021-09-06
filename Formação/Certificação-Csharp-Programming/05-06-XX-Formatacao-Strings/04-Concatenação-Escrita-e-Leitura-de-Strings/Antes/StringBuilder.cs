using System;

namespace _05_06_XX_Formatacao_Strings.Antes
{
    internal class StringBuilder1 : IAulaItem
    {
        public void Executar()
        {
            string materias = "";
            materias = materias + "Português";
            Console.WriteLine(materias);
            materias = materias + ", Matemática";
            Console.WriteLine(materias);
            materias = materias + ", Geografia";
            Console.WriteLine(materias);

            ///<i mage url="$(ProjectDir)/img1.png"/>
        }
    }
}