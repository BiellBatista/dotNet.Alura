using _04_04_XX_Trabalhando_Sobrecargas_Metodos.Intraestrutura;

namespace _04_04_XX_Trabalhando_Sobrecargas_Metodos
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
