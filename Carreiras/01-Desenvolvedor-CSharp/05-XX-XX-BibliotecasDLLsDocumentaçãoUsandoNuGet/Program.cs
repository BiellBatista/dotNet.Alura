using _05_XX_XX_BibliotecasDLLs.Modelos;
using _05_XX_XX_BibliotecasDLLs.Modelos.Funcionarios;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_XX_XX_BibliotecasDLLsDocumentaçãoUsandoNuGet
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dataFimPagamento = new DateTime(2022, 8, 17);
            DateTime dataCorrente = DateTime.Now;
            TimeSpan diferenca = dataFimPagamento.Subtract(dataCorrente);

            //string mensagem = "Vencimento em " + GetIntervaloDeTempoLegivel(diferenca);
            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca, 1, new CultureInfo("pt-Br"));

            Console.WriteLine(mensagem);
            Console.ReadLine();
        }

        static string GetIntervaloDeTempoLegivel(TimeSpan timeSpan)
        {
            if (timeSpan.Days > 30)
            {
                int quantidadeMeses = timeSpan.Days / 30;
                return timeSpan.Days + " meses";
            }

            return timeSpan.Days + " dias";
        }
    }
}
