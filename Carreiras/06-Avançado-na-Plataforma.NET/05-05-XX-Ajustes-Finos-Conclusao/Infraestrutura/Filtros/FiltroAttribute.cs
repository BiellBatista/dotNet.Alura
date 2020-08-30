using System;

namespace _05_05_XX_Ajustes_Finos_Conclusao.Infraestrutura.Filtros
{
    public abstract class FiltroAttribute : Attribute
    {
        public abstract bool PodeContinuar();
    }
}
