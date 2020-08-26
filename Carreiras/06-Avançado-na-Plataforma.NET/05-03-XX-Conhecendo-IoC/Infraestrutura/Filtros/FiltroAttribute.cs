using System;

namespace _05_03_XX_Conhecendo_IoC.Infraestrutura.Filtros
{
    public abstract class FiltroAttribute : Attribute
    {
        public abstract bool PodeContinuar();
    }
}
