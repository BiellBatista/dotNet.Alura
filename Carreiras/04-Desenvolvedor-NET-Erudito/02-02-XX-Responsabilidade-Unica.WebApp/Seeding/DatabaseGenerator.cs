using System;
using System.Collections.Generic;
using _02_02_XX_Responsabilidade_Unica.WebApp.Models;
using _02_02_XX_Responsabilidade_Unica.WebApp.Dados;

namespace _02_02_XX_Responsabilidade_Unica.WebApp.Seeding
{
    public static class DatabaseGenerator
    {
        public static void Seed()
        {
            using (var ctx = new AppDbContext())
            {
                if (ctx.Database.EnsureCreated())
                {
                    var generator = new LeilaoRandomGenerator(new Random());
                    var leiloes = new List<Leilao>();
                    for (var i = 1; i <= 200; i++)
                    {
                        leiloes.Add(generator.NovoLeilao);
                    }
                    ctx.Leiloes.AddRange(leiloes);
                    ctx.SaveChanges();
                }
            }
        }
    }
}