using _05_05_XX_Ajustes_Finos_Conclusao.Infraestrutura;

namespace _05_05_XX_Ajustes_Finos_Conclusao
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
