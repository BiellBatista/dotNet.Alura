using _05_XX_XX_BibliotecasDLLs.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_XX_XX_BibliotecasDLLsDocumentaçãoUsandoNuGet
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(847, 489754);
            Console.WriteLine(conta.Numero);
            Console.ReadLine();
        }
    }
}
