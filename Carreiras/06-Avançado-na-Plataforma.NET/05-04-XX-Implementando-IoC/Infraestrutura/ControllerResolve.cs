using _05_04_XX_Implementando_IoC.Infraestrutura.IoC;
using System;

namespace _05_04_XX_Implementando_IoC.Infraestrutura
{
    public class ControllerResolve
    {
        private readonly IContainer _container;

        public ControllerResolve(IContainer container)
        {
            _container = container;
        }

        public object ObterController(string nomeController)
        {
            var tipoController = Type.GetType(nomeController);
            var instanciaController = _container.Recuperar(tipoController);

            return instanciaController;
        }
    }
}
