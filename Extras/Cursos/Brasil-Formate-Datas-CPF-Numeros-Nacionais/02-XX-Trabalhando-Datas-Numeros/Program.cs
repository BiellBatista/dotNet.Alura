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

        }
    }
}
