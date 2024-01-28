using _05_XX_Fabrica_Comandos.Console.Comandos;
using System.Reflection;

namespace _05_XX_Fabrica_Comandos.Console.Util
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