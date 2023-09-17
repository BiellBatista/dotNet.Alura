using _03_XX_Extraindo_Resultados.Console.Comandos;
using System.Reflection;

namespace _03_XX_Extraindo_Resultados.Console.Util
{
    public class DocumentacaoDoSistema
    {
        public static Dictionary<string, DocComandoAttribute> ToDictionary(Assembly assemblyComOTipoDocComando)
        {
            return assemblyComOTipoDocComando.GetTypes()
             .Where(t => t.GetCustomAttributes<DocComandoAttribute>().Any())
             .Select(t => t.GetCustomAttribute<DocComandoAttribute>()!)
             .ToDictionary(d => d.Instrucao);
        }
    }
}