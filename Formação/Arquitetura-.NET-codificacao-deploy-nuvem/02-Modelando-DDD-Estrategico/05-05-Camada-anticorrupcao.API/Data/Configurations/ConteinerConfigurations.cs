using _05_05_Camada_anticorrupcao.Engenharia.Conteineres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _05_05_Camada_anticorrupcao.API.Data.Configurations;

public class ConteinerConfigurations : IEntityTypeConfiguration<Conteiner>
{
    public void Configure(EntityTypeBuilder<Conteiner> builder)
    {
        builder
            .Property(c => c.Status)
            .HasConversion<string>();
    }
}