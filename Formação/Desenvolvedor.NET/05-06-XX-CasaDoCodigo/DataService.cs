﻿using _05_06_XX_CasaDoCodigo.Models;
using _05_06_XX_CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace _05_06_XX_CasaDoCodigo
{
    public class DataService : IDataService
    {
        public async Task InicializaDBAsync(IServiceProvider provider)
        {
            var contexto = provider.GetService<ApplicationContext>();

            await contexto.Database.MigrateAsync();

            if (await contexto.Set<Produto>().AnyAsync())
            {
                return;
            }

            List<Livro> livros = await GetLivrosAsync();

            var produtoRepository = provider.GetService<IProdutoRepository>();
            await produtoRepository.SaveProdutosAsync(livros);
        }

        private async Task<List<Livro>> GetLivrosAsync()
        {
            var json = await File.ReadAllTextAsync("livros.json");
            return JsonConvert.DeserializeObject<List<Livro>>(json);
        }
    }
}
