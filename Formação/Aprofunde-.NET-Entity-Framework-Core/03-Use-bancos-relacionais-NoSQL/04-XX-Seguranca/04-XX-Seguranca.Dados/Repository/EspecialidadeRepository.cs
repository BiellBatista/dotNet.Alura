﻿using _04_XX_Seguranca.Dados.Repository.Base;
using _04_XX_Seguranca.Dados.Repository.Interfaces;
using _04_XX_Seguranca.Modelos;

namespace _04_XX_Seguranca.Dados.Repository;

public class EspecialidadeRepository : Repository<Especialidade>, IEspecialidadeRepository
{
    public EspecialidadeRepository(FreelandoContext context) : base(context)
    {
    }
}