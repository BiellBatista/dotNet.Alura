using _05_02_Nem_todo_contexto_ilha.Vendas.Locacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _05_02_Nem_todo_contexto_ilha.API.Data.Configurations;

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