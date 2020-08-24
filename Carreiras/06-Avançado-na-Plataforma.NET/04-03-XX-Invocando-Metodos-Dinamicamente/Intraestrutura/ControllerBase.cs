using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace _04_03_XX_Invocando_Metodos_Dinamicamente.Intraestrutura
{
    public abstract class ControllerBase
    {
        //o primeiro método possui o nome do arquivo que chamou este método
        protected string View([CallerMemberName] string nomeArquivo = default)
        {
            var type = GetType();
            var diretorioName = type.Name.Replace("Controller", "");
            var nomeCompletoResource = $"_04_03_XX_Invocando_Metodos_Dinamicamente.View.{diretorioName}.{nomeArquivo}.html";
            var assembly = Assembly.GetExecutingAssembly();
            var streamRecurso = assembly.GetManifestResourceStream(nomeCompletoResource);
            var streamLeitura = new StreamReader(streamRecurso);
            var textoPagina = streamLeitura.ReadToEnd();

            return textoPagina;
        }
    }
}
