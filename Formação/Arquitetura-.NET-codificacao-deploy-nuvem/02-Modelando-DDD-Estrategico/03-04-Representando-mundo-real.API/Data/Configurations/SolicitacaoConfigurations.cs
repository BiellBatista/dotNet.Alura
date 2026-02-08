using _03_04_Representando_mundo_real.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _03_04_Representando_mundo_real.API.Data.Configurations;

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