using _02_XX_Boas_Praticas_Testes.Console.Comandos;
using System.Reflection;

namespace _02_XX_Boas_Praticas_Testes.Console.Util
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