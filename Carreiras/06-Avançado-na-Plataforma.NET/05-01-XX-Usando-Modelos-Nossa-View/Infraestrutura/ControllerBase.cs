using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace _05_01_XX_Usando_Modelos_Nossa_View.Infraestrutura
{
    public abstract class ControllerBase
    {
        protected string View([CallerMemberName] string nomeArquivo = null)
        {
            var type = GetType();
            var diretorioNome = type.Name.Replace("Controller", "");

            var nomeCompletoResource = $"_05_01_XX_Usando_Modelos_Nossa_View.View.{diretorioNome}.{nomeArquivo}.html";
            var assembly = Assembly.GetExecutingAssembly();

            var streamRecurso = assembly.GetManifestResourceStream(nomeCompletoResource);

            var streamLeitura = new StreamReader(streamRecurso);
            var textoPagina = streamLeitura.ReadToEnd();

            return textoPagina;
        }

        protected string View(object model, [CallerMemberName] string nomeArquivo = null)
        {
            var viewBruta = View(nomeArquivo);

            return string.Empty;
        }
    }
}
