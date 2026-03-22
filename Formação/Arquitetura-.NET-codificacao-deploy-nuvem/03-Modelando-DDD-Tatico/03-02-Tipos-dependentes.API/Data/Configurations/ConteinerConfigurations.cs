using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _03_02_Tipos_dependentes.API.Data.Configurations;

public class ConteinerConfigurations : IEntityTypeConfiguration<Conteiner>
{
    public void Configure(EntityTypeBuilder<Conteiner> builder)
    {
        builder
            .Property(c => c.Status)
            .HasConversion<string>();
    }
}