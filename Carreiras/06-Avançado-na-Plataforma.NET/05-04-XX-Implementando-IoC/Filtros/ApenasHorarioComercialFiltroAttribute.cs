using _05_04_XX_Implementando_IoC.Infraestrutura.Filtros;
using System;

namespace _05_04_XX_Implementando_IoC.Filtros
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
