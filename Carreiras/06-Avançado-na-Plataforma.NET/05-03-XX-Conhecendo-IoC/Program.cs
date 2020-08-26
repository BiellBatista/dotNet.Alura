using _05_03_XX_Conhecendo_IoC.Infraestrutura;

namespace _05_03_XX_Conhecendo_IoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var prefixos = new string[] { "http://localhost:5341/" };
            var webApplication = new WebApplication(prefixos);
            webApplication.Iniciar();
        }
    }
}
