using _05_02_Nem_todo_contexto_ilha.Vendas.Propostas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _05_02_Nem_todo_contexto_ilha.API.Data.Configurations;

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