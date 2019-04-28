using _02_05_XX_CasaDoCodigo.Models;
using _02_05_XX_CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace _02_05_XX_CasaDoCodigo
{
    class DataServices : IDataServices
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        public DataServices(ApplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            contexto.Database.Migrate();
            List<Livro> livros = GetLivros();
            produtoRepository.SaveProdutos(livros);
        }

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }
}
