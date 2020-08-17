using _04_01_XX_O_Pontape_Nossa_Aplicacao_Web.Intraestrutura;

namespace _04_01_XX_O_Pontape_Nossa_Aplicacao_Web
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
