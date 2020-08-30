using _05_05_XX_Ajustes_Finos_Conclusao.Infraestrutura.IoC;
using System;

namespace _05_05_XX_Ajustes_Finos_Conclusao.Infraestrutura
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
