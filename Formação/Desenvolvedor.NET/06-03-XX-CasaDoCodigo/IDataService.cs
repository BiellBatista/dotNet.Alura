﻿using System;
using System.Threading.Tasks;

namespace _06_03_XX_CasaDoCodigo
{
    public interface IDataService
    {
        Task InicializaDBAsync(IServiceProvider provider);
    }
}