﻿using _06_XX_Filmes.API.Models;
using Microsoft.EntityFrameworkCore;

namespace _06_XX_Filmes.API.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {
    }

    public DbSet<Filme> Filmes { get; set; }
}