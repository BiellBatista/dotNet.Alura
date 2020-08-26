using _05_03_XX_Conhecendo_IoC.Infraestrutura.Filtros;
using System;

namespace _05_03_XX_Conhecendo_IoC.Filtros
{
    public class ApenasHorarioComercialFiltroAttribute : FiltroAttribute
    {
        public override bool PodeContinuar()
        {
            var hora = DateTime.Now.Hour;

            return hora >= 9 && hora < 16;
        }
    }
}
