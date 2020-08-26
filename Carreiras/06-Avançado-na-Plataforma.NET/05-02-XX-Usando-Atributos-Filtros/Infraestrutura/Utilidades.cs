using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace _05_02_XX_Usando_Atributos_Filtros.Infraestrutura
{
    public static class Utilidades
    {

        public static bool EhArquivo(string path)
        {
            // /Assets/css/styles.css
            // /Assets/js/main.js

            var partesPath = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var ultimaParte = partesPath.Last();

            return ultimaParte.Contains('.');
        }

        public static string ConverterPathParaNomeAssembly(string path)
        {
            var prefixoAssembly = "_05_02_XX_Usando_Atributos_Filtros";
            var pathComPontos = path.Replace('/', '.');

            var nomeCompleto = $"{prefixoAssembly}{pathComPontos}";

            return nomeCompleto;
        }

        public static Stream ObterStreamDePagina(string nomeCompleto)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(nomeCompleto);
        }

        public static string ObterTipoDeConteudo(string path)
        {
            if (path.EndsWith(".css"))
                return "text/css; charset=utf-8";

            if (path.EndsWith(".js"))
                return "application/js; charset=utf-8";

            if (path.EndsWith(".html"))
                return "text/html; charset=utf-8";

            throw new NotImplementedException("Tipo de conteúdo não previsto!");
        }
    }
}
