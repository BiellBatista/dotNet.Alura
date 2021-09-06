using System;

namespace _02_05_XX_Adicionando_Membros_Dinamicamente.Depois
{
    internal class UsandoDynamic : IAulaItem
    {
        public void Executar()
        {
            //o tipo é definido em tempo de compilação
            string s = "Certificação C#";
            //o tipo é definido em tempo de compilação (por inferência)
            var v = "Certificação C#";
            //o tipo é definido em tempo de compilação
            object o = "Certificação C#";

            Console.WriteLine(s);
            Console.WriteLine(v);
            Console.WriteLine(o);

            s = s.ToUpper();
            v = v.ToUpper();
            o = ((string)o).ToUpper();

            Console.WriteLine(s);
            Console.WriteLine(v);
            Console.WriteLine(o);

            o = 123;
            o = (int)o + 4;

            Console.WriteLine(o);

            //o tipo é definido em tempo de execução
            dynamic d = "Certificação C#";
            Console.WriteLine(d);

            d = d.ToUpper();
            Console.WriteLine(d);

            //trocando o tipo, em tempo de execução (estilo JavaScript)
            d = 123;
            Console.WriteLine(d);

            d = d + 4;
            Console.WriteLine(d);
        }
    }
}