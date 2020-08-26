using System;

namespace _05_02_XX_Usando_Atributos_Filtros.Infraestrutura.Filtros
{
    public abstract class FiltroAttribute : Attribute
    {
        public abstract bool PodeContinuar();
    }
}
