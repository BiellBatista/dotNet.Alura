namespace _02_XX_Mapeamentos_explicitos.Dados.Mapeamentos;
internal class ContratoTypeConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> entity)
    {
        entity.ToTable("TB_Contratos");
        entity.Property(e => e.Id).HasColumnName("Id_Contrato");
        entity.OwnsOne(e => e.Vigencia, vigencia =>
        {
            vigencia.Property(v => v.DataInicio).HasColumnName("Data_Inicio");
            vigencia.Property(v => v.DataEncerramento).HasColumnName("Data_Encerramento");
        });
    }
}