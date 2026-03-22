using _02_04_Aprovacao_proposta.Vendas.Propostas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _02_04_Aprovacao_proposta.API.Data.Configurations;

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