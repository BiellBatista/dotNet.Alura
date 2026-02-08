using _03_03_Usando_glossario_fonte.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _03_03_Usando_glossario_fonte.API.Data.Configurations;

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