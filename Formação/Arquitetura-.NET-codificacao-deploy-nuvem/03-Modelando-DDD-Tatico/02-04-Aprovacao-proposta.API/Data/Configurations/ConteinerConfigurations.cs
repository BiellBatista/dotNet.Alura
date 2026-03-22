using _02_04_Aprovacao_proposta.Engenharia.Conteineres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _02_04_Aprovacao_proposta.API.Data.Configurations;

public class ConteinerConfigurations : IEntityTypeConfiguration<Conteiner>
{
    public void Configure(EntityTypeBuilder<Conteiner> builder)
    {
        builder
            .Property(c => c.Status)
            .HasConversion<string>();
    }
}