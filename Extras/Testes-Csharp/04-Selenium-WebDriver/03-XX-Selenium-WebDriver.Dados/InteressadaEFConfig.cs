using _03_XX_Selenium_WebDriver.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _03_XX_Selenium_WebDriver.Dados
{
    internal class InteressadaEFConfig : IEntityTypeConfiguration<Interessada>
    {
        public void Configure(EntityTypeBuilder<Interessada> builder)
        {
            builder.HasData(
                new Interessada("Fulano de Tal") { Id = 1 },
                new Interessada("Mariana Mary") { Id = 2 },
                new Interessada("Sicrana Silva") { Id = 3 } );
        }
    }
}