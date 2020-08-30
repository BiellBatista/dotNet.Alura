using _05_04_XX_Implementando_IoC.Infraestrutura;

namespace _05_04_XX_Implementando_IoC
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
