using _04_09_XX_Facades_Singletons.Facades;

namespace _04_09_XX_Facades_Singletons.Singletons
{
    public class EmpresaFacadeSingleton
    {
        private static EmpresaFacade instancia = new EmpresaFacade();

        public EmpresaFacade Instancia
        {
            get
            {
                return instancia;
            }
        }
    }
}
