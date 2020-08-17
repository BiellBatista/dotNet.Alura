using System;

namespace _04_02_XX_Usando_Assembly_Dinamicamente_Convencoes.Intraestrutura
{
    public static class Utilidades
    {
        public static string ConverterPathParaNomeAssembly(string path)
        {
            var prefixoAssembly = "04-02-XX-Usando-Assembly-Dinamicamente-Convencoes";
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
    }
}
