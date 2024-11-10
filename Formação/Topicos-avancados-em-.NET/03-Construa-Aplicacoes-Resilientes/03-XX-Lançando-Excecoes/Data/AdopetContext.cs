using _03_XX_Lançando_Excecoes.Models;
using Microsoft.EntityFrameworkCore;

namespace _03_XX_Lançando_Excecoes.Data;

public class AdopetContext : DbContext
{
    public AdopetContext(DbContextOptions<AdopetContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adocao>()
            .HasOne(a => a.Pet)
            .WithOne(p => p.Adocao)
            .HasForeignKey<Adocao>(a => a.PetId);

        modelBuilder.Entity<Adocao>()
            .HasOne(a => a.Tutor)
            .WithMany(t => t.Adocoes)
            .HasForeignKey(a => a.TutorId);
    }

    public DbSet<Adocao> Adocoes { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Tutor> Tutores { get; set; }
}