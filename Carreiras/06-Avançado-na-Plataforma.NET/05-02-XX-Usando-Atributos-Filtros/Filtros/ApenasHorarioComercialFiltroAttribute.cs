using _05_02_XX_Usando_Atributos_Filtros.Infraestrutura.Filtros;
using System;

namespace _05_02_XX_Usando_Atributos_Filtros.Filtros
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
