using System;
using System.Linq;

namespace _04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.Intraestrutura
{
    public static class Utilidades
    {
        public static string ConverterPathParaNomeAssembly(string path)
        {
            var prefixoAssembly = "_04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente";
            var pathComPontos = path.Replace('/', '.');
            var nomeCompleto = $"{prefixoAssembly}{pathComPontos}";

            return nomeCompleto;
        }

        public static string ObterTipoDeConteudo(string path)
        {
            if (path.EndsWith(".css"))
                return "text/css; charset=utf-8";
            else if (path.EndsWith(".js"))
                return "application/js; charset=utf-8";
            else if (path.EndsWith(".html"))
                return "text/html; charset=utf-8";

            throw new NotImplementedException("Tipo de conteúdo não previsto!");
        }

        public static bool EhArquivo(string path)
        {
            var partesPath = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var ultimaParte = partesPath.Last();

            return ultimaParte.Contains('.');
        }
    }
}
