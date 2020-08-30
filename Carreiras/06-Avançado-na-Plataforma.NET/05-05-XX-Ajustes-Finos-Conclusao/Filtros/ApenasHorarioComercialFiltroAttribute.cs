using _05_05_XX_Ajustes_Finos_Conclusao.Infraestrutura.Filtros;
using System;

namespace _05_05_XX_Ajustes_Finos_Conclusao.Filtros
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
