using _03_05_XX_Boas_Praticas_Configuracoes.Console.Atributos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos;
using System.Reflection;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Extensions;

public static class ComandoExtensions
{
    public static Type? GetTipoDoComando(this Assembly assembly, string comando)
    {
        return assembly
            .GetTypes()
            // filtre todos os tipos concretos que implementam IComando
            // IComando cmd = new Import(...)
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComando)))
            // filtre os comandos que atendem a instrução armazenada em "comando"
            .Where(c => c.GetCustomAttributes<DocComandoAttribute>()
                .Any(a => a.Instrucao.Equals(comando)))
            .FirstOrDefault();
    }
}