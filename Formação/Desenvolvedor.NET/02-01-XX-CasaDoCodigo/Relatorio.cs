﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _02_01_XX_CasaDoCodigo
{
    public class Relatorio : IRelatorio
    {
        private readonly ICatalogo catalogo;

        public Relatorio(ICatalogo catalogo)
        {
            this.catalogo = catalogo;
        }

        public async Task Imprimir(HttpContext context)
        {
            foreach (var livro in catalogo.GetLivros())
                //o \r é o return. Ou seja, retorne uma nova linha
                await context.Response.WriteAsync($"{livro.Codigo,-10}{livro.Nome,-40}{livro.Preco.ToString("C"),10}\r\n");
        }
    }
}
