using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _03_02_Tipos_dependentes.API.Data.Configurations;

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