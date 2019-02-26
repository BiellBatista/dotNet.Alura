using _04_01_XX_AprendaCriarRelatorioPaginacao.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_01_XX_AprendaCriarRelatorioPaginacao
{
    class Program
    {
        static void Main(string[] args)
        {
            // quebrando as páginas. AUla01
            //const int TAMANHO_PAGINA = 10;

            //using (var contexto = new AluraTunesEntities())
            //{
            //    var numeroNotasFiscais = contexto.NotaFiscals.Count();
            //    var numeroPaginas = Math.Ceiling((decimal)numeroNotasFiscais / TAMANHO_PAGINA);

            //    for (int p = 1; p <= numeroPaginas; p++)
            //        ImprimirPagina(TAMANHO_PAGINA, contexto, p);

            //}

            using (var contexto = new AluraTunesEntities())
            {
                var faixasQuery = from f in contexto.Faixas
                                  where f.ItemNotaFiscals.Count() > 0
                                  let TotalDeVendas = f.ItemNotaFiscals.Sum(inf => inf.Quantidade * inf.PrecoUnitario)
                                  orderby TotalDeVendas descending
                                  select new
                                  {
                                      Id = f.FaixaId,
                                      Nome = f.Nome,
                                      Total = TotalDeVendas
                                  };

                var produtoMaisVendido = faixasQuery.First();

                Console.WriteLine("{0}\t{1}\t{2}", produtoMaisVendido.Id, produtoMaisVendido.Nome, produtoMaisVendido.Total);

                // listando todos os produtos
                foreach (var faixa in faixasQuery)
                    Console.WriteLine("{0}\t{1}\t{2}", faixa.Id, faixa.Nome, faixa.Total);

                var query = from inf in contexto.ItemNotaFiscals
                            where inf.FaixaId == produtoMaisVendido.Id
                            select new
                            {
                                NomeClient = inf.NotaFiscal.Cliente.PrimeiroNome + " " + inf.NotaFiscal.Cliente.Sobrenome
                            };

                // mostrando os cliente que compraram o produto mais vendido
                foreach (var client in query)
                    Console.WriteLine(client.NomeClient);
            }
        }

        private static void UsandoSubConsulta()
        {
            using (var contexto = new AluraTunesEntities())
            {
                decimal queryMedia = contexto.NotaFiscals.Average(n => n.Total);
                var query = from nf in contexto.NotaFiscals
                            where nf.Total > /*subconsulta ->*/queryMedia
                            orderby nf.Total descending //ordenação descrecente
                            select new
                            {
                                Numero = nf.NotaFiscalId,
                                Data = nf.DataNotaFiscal,
                                Cliente = nf.Cliente.PrimeiroNome + nf.Cliente.Sobrenome,
                                Valor = nf.Total
                            };

                foreach (var nf in query)
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                        nf.Numero,
                        nf.Data,
                        nf.Cliente,
                        nf.Valor);
                Console.WriteLine("A média é de: {0}", queryMedia);
            }
        }

        private static void ImprimirPagina(int TAMANHO_PAGINA, AluraTunesEntities contexto, int numeroPagina)
        {
            // paginando uma consulta. Limitando para X (10) páginas

            var query = from nf in contexto.NotaFiscals
                        orderby nf.NotaFiscalId
                        select new
                        {
                            Numero = nf.NotaFiscalId,
                            Data = nf.DataNotaFiscal,
                            Cliente = nf.Cliente.PrimeiroNome + nf.Cliente.Sobrenome,
                            Total = nf.Total
                        };

            int numeroDePulos = (numeroPagina - 1) * TAMANHO_PAGINA;

            query = query.Skip(numeroDePulos); //ele só funciona em lista ordenada
            query = query.Take(TAMANHO_PAGINA);

            Console.WriteLine();
            Console.WriteLine("Número da Página: {0}", numeroPagina);

            foreach (var nf in query)
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", nf.Numero, nf.Data, nf.Cliente, nf.Total);
        }
    }
}
