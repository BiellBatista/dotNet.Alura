using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_01_XX_ConhecendoOProblemaDoCliente.Sistemas
{
    public interface IAutenticavel
    {
        bool Autenticar(string senha);
    }
}
