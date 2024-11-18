﻿using _01_XX_Melhorando_consultas.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _01_XX_Melhorando_consultas.Dados;

public class FreelandoContext : DbContext
{
    private readonly IConfiguration _configuration;

    public FreelandoContext(DbContextOptions<FreelandoContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConnectionStrings:DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FreelandoContext).Assembly);
    }

    public DbSet<Candidatura> Candidaturas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Contrato> Contratos { get; set; }
    public DbSet<Especialidade> Especialidades { get; set; }
    public DbSet<Profissional> Profissionais { get; set; }
    public DbSet<Projeto> Projetos { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<ProjetoEspecialidade> ProjetosEspecialides { get; set; }
}