using _04_XX_Salvando_dados.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04_XX_Salvando_dados.Dados.Mapeamentos;

internal class ClienteTypeConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> entity)
    {
        entity.ToTable("TB_Clientes");

        entity.Property(e => e.Id).HasColumnName("Id_Cliente");
    }
}