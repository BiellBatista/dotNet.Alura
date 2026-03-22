using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _02_04_Aprovacao_proposta.API.Data.Configurations;

public class EnderecoConfigurations : IEntityTypeConfiguration<EnderecoCli>
{
    public void Configure(EntityTypeBuilder<EnderecoCli> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CEP).IsRequired();
        builder.Property(e => e.Estado).HasConversion<string>();
        builder.HasOne(e => e.Cliente)
            .WithMany(c => c.Enderecos)
            .HasForeignKey(e => e.ClienteId);
    }
}