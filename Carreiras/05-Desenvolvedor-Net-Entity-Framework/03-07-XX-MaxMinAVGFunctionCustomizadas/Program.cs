using _03_07_XX_MaxMinAVGFunctionCustomizadas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_07_XX_MaxMinAVGFunctionCustomizadas
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraTunesEntities())
            {
                var mediaVenda = contexto.NotaFiscals.Average(nf => nf.Total);
                Console.WriteLine("Venda Média: {0}", mediaVenda);

                // selecionando o total
                var query = from nf in contexto.NotaFiscals select nf.Total;

                var contagem = query.Count();
                var queryOrdenada = query.OrderBy(total => total);
                // vá até a metade dos dados e pegue o primeiro
                // só é possível fazer um skip, com a consulta ordenada
                //var elementoCentral = query.Skip(contagem / 2).First();
                var elementoCentral = queryOrdenada.Skip(contagem / 2).First();

                var mediana = elementoCentral;

                Console.WriteLine("Mediana: {0}", mediana);
            }
        }

        private static void MaximoMinimoMedia()
        {
            using (var contexto = new AluraTunesEntities())
            {
                // mostrando as consulta no console
                contexto.Database.Log = Console.WriteLine;

                //pegando o maior valor de uma nota fiscal, o atributo Total possui o valor total de uma nota fiscal
                var maiorVenda = contexto.NotaFiscals.Max(nf => nf.Total);
                var menorVenda = contexto.NotaFiscals.Min(nf => nf.Total);
                var mediaVenda = contexto.NotaFiscals.Average(nf => nf.Total);

                Console.WriteLine("A amior venda é de R${0}", maiorVenda);
                Console.WriteLine("A menor venda é de R${0}", menorVenda);
                Console.WriteLine("A média da venda é de R${0}", mediaVenda);

                // realizando uma consulta que retorna diversos valores
                var vendas = (from nf in contexto.NotaFiscals
                              group nf by 1 into agrupado
                              select new
                              {
                                  MaiorVenda = agrupado.Max(nf => nf.Total),
                                  MenorVenda = agrupado.Min(nf => nf.Total),
                                  MediaVenda = agrupado.Average(nf => nf.Total)
                              }).Single(); // o método Single();, tranforma uma consulta em um objeto. Com isso, consigo acessar os atributos MaiorVenda, MenorVenda e MediaVenda

                Console.WriteLine("A amior venda é de R${0}", vendas.MaiorVenda);
                Console.WriteLine("A menor venda é de R${0}", vendas.MenorVenda);
                Console.WriteLine("A média da venda é de R${0}", vendas.MediaVenda);
            }
        }
    }
}
