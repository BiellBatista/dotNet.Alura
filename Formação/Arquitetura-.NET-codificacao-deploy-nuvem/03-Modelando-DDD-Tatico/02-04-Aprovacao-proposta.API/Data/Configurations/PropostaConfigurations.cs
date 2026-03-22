using _02_04_Aprovacao_proposta.Vendas.Propostas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _02_04_Aprovacao_proposta.API.Data.Configurations;

public class PropostaConfigurations : IEntityTypeConfiguration<Proposta>
{
    public void Configure(EntityTypeBuilder<Proposta> builder)
    {
        builder.Property(p => p.ValorTotal)
            .HasColumnType("decimal(18,2)");

        builder.OwnsOne(p => p.Situacao, status =>
        {
            status.Property(s => s.Status)
                .HasColumnName("Status")
                .HasConversion<string>();
        });

        builder.HasOne(p => p.Solicitacao)
            .WithMany(s => s.Propostas)
            .HasForeignKey(p => p.SolicitacaoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}