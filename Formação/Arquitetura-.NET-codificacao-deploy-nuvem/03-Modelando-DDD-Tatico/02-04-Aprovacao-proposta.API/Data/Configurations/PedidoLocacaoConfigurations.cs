using _02_04_Aprovacao_proposta.Vendas.Propostas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _02_04_Aprovacao_proposta.API.Data.Configurations;

public class PedidoLocacaoConfigurations : IEntityTypeConfiguration<PedidoLocacao>
{
    public void Configure(EntityTypeBuilder<PedidoLocacao> builder)
    {
        builder.OwnsOne(s => s.Status, status =>
        {
            status.Property(s => s.Status)
                .HasColumnName("Status")
                .HasConversion<string>();
        });

        builder.OwnsOne(p => p.Localizacao, end =>
        {
            end.Property(e => e.CEP).IsRequired();
            // outras propriedades serão mapeadas por convenção
        });
    }
}