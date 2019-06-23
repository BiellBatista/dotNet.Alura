using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alura.Filmes.App.Dados
{
    internal class FuncionarioConfiguration : PessoaConfiguration<Funcionario>
    {
        /*
         * Configurando uma herança entre as classes e compartilhando as configurações do Entity Framework
         */
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("staff");

            builder
                .Property(f => f.Id)
                .HasColumnName("staff_id");

            builder
                .Property(f => f.Login)
                .HasColumnName("username")
                .HasColumnType("varchar(16)")
                .IsRequired();

            builder
                .Property(f => f.Senha)
                .HasColumnName("password")
                .HasColumnType("varchar(40)");
        }
    }
}
