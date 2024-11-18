using _03_XX_Topicos_Transacoes.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _03_XX_Topicos_Transacoes.Dados.Mapeamentos;

internal class ProfissionalTypeConfiguration : IEntityTypeConfiguration<Profissional>
{
    public void Configure(EntityTypeBuilder<Profissional> entity)
    {
        entity.ToTable("TB_Profissionais");

        entity.Property(e => e.Id).HasColumnName("Id_Profissional");

        entity
            .HasMany(e => e.Especialidades)
            .WithMany(e => e.Profissionais)
            .UsingEntity<ProfissionalEspecialidade>(
            l => l.HasOne(e => e.Especialidade).WithMany(e => e.ProfissionaisEspecialidade).HasForeignKey(e => e.EspecialidadeId),
            r => r.HasOne(e => e.Profissional).WithMany(e => e.ProfissionaisEspecialidade).HasForeignKey(e => e.ProfissionalId)
            );
    }
}