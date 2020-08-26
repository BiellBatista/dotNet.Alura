using _05_02_XX_Usando_Atributos_Filtros.Infraestrutura;

namespace _05_02_XX_Usando_Atributos_Filtros
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
