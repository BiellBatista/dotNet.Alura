using _04_02_Linguagens_consistentes.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04_02_Linguagens_consistentes.API.Data.Configurations;

public class SolicitacaoConfigurations : IEntityTypeConfiguration<PedidoLocacao>
{
    public void Configure(EntityTypeBuilder<PedidoLocacao> builder)
    {
        builder.OwnsOne(s => s.Status, status =>
        {
            status.Property(s => s.Status)
                .HasColumnName("Status")
                .HasConversion<string>();
        });
    }
}