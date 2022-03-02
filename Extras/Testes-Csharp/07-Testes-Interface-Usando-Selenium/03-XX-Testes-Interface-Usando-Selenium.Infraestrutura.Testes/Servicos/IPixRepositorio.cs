using _03_XX_Testes_Interface_Usando_Selenium.Infraestrutura.Testes.DTO;
using System;

namespace _03_XX_Testes_Interface_Usando_Selenium.Infraestrutura.Testes
{
    public interface IPixRepositorio
    {
        public PixDTO consultaPix(Guid pix);
    }
}