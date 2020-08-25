using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace _04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.Intraestrutura
{
    public abstract class ControllerBase
    {
        //o primeiro método possui o nome do método que chamou este método
        protected string View([CallerMemberName] string nomeArquivo = default)
        {
            var type = GetType();
            var diretorioName = type.Name.Replace("Controller", "");
            var nomeCompletoResource = $"_04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.View.{diretorioName}.{nomeArquivo}.html";
            var assembly = Assembly.GetExecutingAssembly();
            var streamRecurso = assembly.GetManifestResourceStream(nomeCompletoResource);
            var streamLeitura = new StreamReader(streamRecurso);
            var textoPagina = streamLeitura.ReadToEnd();

            return textoPagina;
        }
    }
}
