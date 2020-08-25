using _04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.Intraestrutura;

namespace _04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente
{
    class Program
    {
        static void Main(string[] args)
        {
            var prefixo = new string[] { "http://localhost:5341/" };
            var webApplication = new WebApplication(prefixo);

            webApplication.Iniciar();
        }
    }
}
