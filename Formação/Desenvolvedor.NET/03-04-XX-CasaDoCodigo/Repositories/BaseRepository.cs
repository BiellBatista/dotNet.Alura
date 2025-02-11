﻿using _03_04_XX_CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace _03_04_XX_CasaDoCodigo.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext contexto;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<T>();
        }
    }
}
