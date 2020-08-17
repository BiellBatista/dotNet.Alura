using _04_02_XX_Usando_Assembly_Dinamicamente_Convencoes.Intraestrutura;

namespace _04_02_XX_Usando_Assembly_Dinamicamente_Convencoes
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
