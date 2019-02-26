using _04_02_XX_AnaliseAfinidadeSugerirCompras.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_02_XX_AnaliseAfinidadeSugerirCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            // análise de afinidade
            var nomeDaMusica = "Smells Like Teen Spirit";

            using (var contexto = new AluraTunesEntities())
            {
                var faixaIds = contexto.Faixas.Where(f => f.Nome == nomeDaMusica).Select(f => f.FaixaId);

                var query = from comprouItem in contexto.ItemNotaFiscals
                            join comprouTambem in contexto.ItemNotaFiscals
                                on comprouItem.NotaFiscalId equals comprouTambem.NotaFiscalId
                            where faixaIds.Contains(comprouItem.FaixaId)
                                && comprouItem.FaixaId != comprouTambem.FaixaId
                            select comprouTambem;

                foreach (var item in query)
                    Console.WriteLine("{0}\t{1}", item.NotaFiscalId, item.Faixa.Nome);

                /*
                 * 
                 * var query = 
    from esteProduto in contexto.ItemsNotaFiscal
    join outroProduto in contexto.ItemsNotaFiscal
        on esteProduto.NotaFiscalId equals outroProduto.NotaFiscalId
    where esteProduto.FaixaId != outroProduto.FaixaId
    && esteProduto.FaixaId == 1
    orderby esteProduto.FaixaId
    select new { esteProduto, outroProduto };
                 */
            }
        }
    }
}
