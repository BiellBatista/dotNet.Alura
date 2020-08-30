using _05_04_XX_Implementando_IoC.Infraestrutura;

namespace _05_04_XX_Implementando_IoC.Controller
{
    public class ErroController : ControllerBase
    {
        public string Inesperado() => View();
    }
}
