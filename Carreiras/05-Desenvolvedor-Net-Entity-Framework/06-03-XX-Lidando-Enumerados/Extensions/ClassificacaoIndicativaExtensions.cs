using Alura.Filmes.App.Negocio;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Filmes.App.Extensions
{
    public static class ClassificacaoIndicativaExtensions
    {
        private static Dictionary<string, ClassificacaoIndicativa> mapa = new Dictionary<string, ClassificacaoIndicativa>
            {
                { "G", ClassificacaoIndicativa.Livre },
                { "PG", ClassificacaoIndicativa.MaioresQue10 },
                { "PG-13", ClassificacaoIndicativa.MaioresQue13 },
                { "R", ClassificacaoIndicativa.MaioresQue14 },
                { "NC-17", ClassificacaoIndicativa.MaioresQue18 }
            };

        //criando método de extensão
        public static string ParaString(this ClassificacaoIndicativa valor) => mapa.First(c => c.Value == valor).Key;

        public static ClassificacaoIndicativa ParaValor(this string texto) => mapa.First(c => c.Key == texto).Value;
    }
}
