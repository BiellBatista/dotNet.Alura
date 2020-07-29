using Caelum.Stella.CSharp.Inwords;
using System;
using System.Diagnostics;
using System.Globalization;

namespace _02_XX_Trabalhando_Datas_Numeros
{
    class Program
    {
        static void Main(string[] args)
        {
            //formatando datas
            DateTime data = new DateTime(2017, 9, 23);
            Debug.WriteLine(data);
            Debug.WriteLine(data.ToString("d"));
            Debug.WriteLine(data.ToString("d", new CultureInfo("pt-BR")));
            Debug.WriteLine(data.ToString("dd/MM"));
            Debug.WriteLine(data.ToString("dd/MM/yy"));

            //formatando horas
            data = new DateTime(2017, 9, 23, 13, 14, 15, 987);
            Debug.WriteLine(data);
            Debug.WriteLine(data.ToString("HH:mm"));
            Debug.WriteLine(data.ToString("HH:mm:ss.fff"));

            //formatos simplificados
            Debug.WriteLine(data.ToString("D"));
            Debug.WriteLine(data.ToString("m"));
            Debug.WriteLine(data.ToString("Y"));

            Debug.WriteLine(data.ToString("G")); //data e hora por extenso com os segundos
            Debug.WriteLine(data.ToString("g")); //data e hora por extenso sem os segundos

            Debug.WriteLine(data.ToString("O")); //formato de ida e volta (ToISOString)
            Debug.WriteLine(DateTime.Parse(data.ToString("O")).ToString("dd/MM/yyyy HH:mm:ss.fff"));

            Debug.WriteLine(data.ToString("t")); //Horas e minutos
            Debug.WriteLine(data.ToString("T")); //Horas minutos e segundos

            //numeros por extenso (usando a biblioteca caelum)
            double valor = 75;
            string extenso = new Numero(valor).Extenso();
            Debug.WriteLine(extenso);

            valor = 1532987;
            extenso = new Numero(valor).Extenso();
            Debug.WriteLine(extenso);

            string extensoBRL = new MoedaBRL(valor).Extenso();
            Debug.WriteLine(extensoBRL);

            valor = 1532987.89;
            extensoBRL = new MoedaBRL(valor).Extenso();
            Debug.WriteLine(extensoBRL);
        }
    }
}
