using _05_XX_Consultas.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _05_XX_Consultas.Dados.Mapeamentos;

internal class ClienteTypeConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> entity)
    {
        entity.ToTable("TB_Clientes");

        entity.Property(e => e.Id).HasColumnName("Id_Cliente");
    }
}