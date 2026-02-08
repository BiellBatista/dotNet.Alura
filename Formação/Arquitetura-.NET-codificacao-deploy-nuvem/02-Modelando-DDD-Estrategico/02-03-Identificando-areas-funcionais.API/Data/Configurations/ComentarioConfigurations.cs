using _02_03_Identificando_areas_funcionais.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _02_03_Identificando_areas_funcionais.API.Data.Configurations;

public class ComentarioConfigurations : IEntityTypeConfiguration<Comentario>
{
    public void Configure(EntityTypeBuilder<Comentario> builder)
    {
        builder.HasOne(c => c.Proposta)
            .WithMany(p => p.Comentarios)
            .HasForeignKey(c => c.PropostaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}