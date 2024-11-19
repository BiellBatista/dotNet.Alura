using _06_XX_EF_MongoDB.API.Entidades;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace _06_XX_EF_MongoDB.API.Context;

public class ClickBonusMongoDBContext : DbContext
{
    public DbSet<Bonus> Bonuses { get; set; }

    public ClickBonusMongoDBContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Bonus>().ToCollection("bonus");
    }
}