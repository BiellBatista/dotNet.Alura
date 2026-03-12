using _05_05_Camada_anticorrupcao.Vendas.Locacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _05_05_Camada_anticorrupcao.API.Data.Configurations;

public class LocacaoConfigurations : IEntityTypeConfiguration<Locacao>
{
    public void Configure(EntityTypeBuilder<Locacao> builder)
    {
        builder.OwnsOne(locacao => locacao.Status, status =>
        {
            status.Property(s => s.Status)
                .HasColumnName("Status")
                .HasConversion<string>();
        });

        builder.HasOne(l => l.Proposta)
            .WithOne()
            .HasForeignKey<Locacao>(l => l.PropostaId);
    }
}