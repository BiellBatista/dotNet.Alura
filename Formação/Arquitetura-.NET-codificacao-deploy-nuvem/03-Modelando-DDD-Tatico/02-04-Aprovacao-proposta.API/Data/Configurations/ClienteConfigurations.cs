using _02_04_Aprovacao_proposta.Clientes.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _02_04_Aprovacao_proposta.API.Data.Configurations;

public class ClienteConfigurations : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Nome).IsRequired();

        builder
            .OwnsOne(c => c.Email, cfg =>
            {
                cfg.Property(e => e.Value)
                    .HasColumnName("Email")
                    .IsRequired();
            });

        builder
            .Property(c => c.CPF).IsRequired();
    }
}