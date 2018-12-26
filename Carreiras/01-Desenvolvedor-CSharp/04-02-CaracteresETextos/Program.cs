using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_02_CaracteresETextos
{
    class Program
    {
        static void Main(string[] args)
        {
            // o @ serve para considerar tudo que estiver entre aspas dupla("")
            string cursoPorgrama = @"- .NET
- Java
- JavaScript";
            char valor = (char) 65;
            Console.WriteLine(valor);
            Console.WriteLine(cursoPorgrama);
            Console.ReadLine();
        }
    }
}
