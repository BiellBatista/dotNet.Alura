﻿using _03_03_XX_CasaDoCodigo.Models;

namespace _03_03_XX_CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {

    }

    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
