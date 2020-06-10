using _03_XX_Selenium_WebDriver.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _03_XX_Selenium_WebDriver.Dados
{
    internal class UsuarioEFConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(new { Id = 1, Email = "fulano@example.org", Senha = "123", InteressadaId = 1 });
            builder.HasData(new { Id = 2, Email = "mariana@example.org", Senha = "456", InteressadaId = 2 });
            builder.HasData(new { Id = 3, Email = "admin@example.org", Senha = "123" });
        }
    }
}