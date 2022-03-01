using _02_XX_Testes_Interface_Usando_Selenium.Infraestrutura.Testes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_XX_Testes_Interface_Usando_Selenium.Infraestrutura.Testes
{
    public interface IPixRepositorio
    {
       public PixDTO consultaPix(Guid pix);
    }
}
