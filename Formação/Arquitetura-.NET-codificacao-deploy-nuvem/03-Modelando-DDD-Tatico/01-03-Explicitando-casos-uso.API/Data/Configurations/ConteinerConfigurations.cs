using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_03_Explicitando_casos_uso.API.Data.Configurations;

public class ConteinerConfigurations : IEntityTypeConfiguration<Conteiner>
{
    public void Configure(EntityTypeBuilder<Conteiner> builder)
    {
        builder
            .Property(c => c.Status)
            .HasConversion<string>();
    }
}