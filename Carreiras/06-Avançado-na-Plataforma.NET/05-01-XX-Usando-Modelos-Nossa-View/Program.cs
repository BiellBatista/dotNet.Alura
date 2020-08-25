using _05_01_XX_Usando_Modelos_Nossa_View.Infraestrutura;

namespace _05_01_XX_Usando_Modelos_Nossa_View
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
