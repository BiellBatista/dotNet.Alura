﻿using _03_XX_Trabalhando_cache.Dados.Repository.Base;
using _03_XX_Trabalhando_cache.Dados.Repository.Interfaces;
using _03_XX_Trabalhando_cache.Modelos;

namespace _03_XX_Trabalhando_cache.Dados.Repository;

public class EspecialidadeRepository : Repository<Especialidade>, IEspecialidadeRepository
{
    public EspecialidadeRepository(FreelandoContext context) : base(context)
    {
    }
}