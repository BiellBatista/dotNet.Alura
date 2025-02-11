﻿using _03_XX_Relacionamento_1_N.Models;
using Microsoft.EntityFrameworkCore;

namespace _03_XX_Relacionamento_1_N.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema) //o endereço tem um cinema
                .WithOne(cinema => cinema.Endereco) //um cinema possui um endereço
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId); //chave de referencia do endereço está no cinema e é o EnderecoId

            builder
                .Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId)
                .OnDelete(DeleteBehavior.Restrict); //removendo a deleção em cascata
        }
    }
}