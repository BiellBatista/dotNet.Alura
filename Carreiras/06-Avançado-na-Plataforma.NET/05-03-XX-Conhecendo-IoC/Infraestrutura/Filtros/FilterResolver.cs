﻿using _05_03_XX_Conhecendo_IoC.Infraestrutura.Binding;
using System;

namespace _05_03_XX_Conhecendo_IoC.Infraestrutura.Filtros
{
    public class FilterResolver
    {
        public FilterResult VerificarFiltros(ActionBindInfo actionBindInfo)
        {
            var methodInfo = actionBindInfo.MethodInfo;
            var atributos = methodInfo.GetCustomAttributes(typeof(FiltroAttribute), false);

            foreach (FiltroAttribute filtro in atributos)
                if (!filtro.PodeContinuar())
                    return new FilterResult(false);
            return new FilterResult(true);
        }
    }
}
