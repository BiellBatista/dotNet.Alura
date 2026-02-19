using _04_02_Linguagens_consistentes.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04_02_Linguagens_consistentes.API.Data.Configurations;

public class EnderecoConfigurations : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CEP).IsRequired();
        builder.Property(e => e.Estado).HasConversion<string>();
        builder.HasOne(e => e.Cliente)
            .WithMany(c => c.Enderecos)
            .HasForeignKey(e => e.ClienteId);
    }
}