using _04_XX_Integrando_Aplicacao_Banco_Dados.Infraestrutura.Testes.DTO;
using System;

namespace _04_XX_Integrando_Aplicacao_Banco_Dados.Infraestrutura.Testes
{
    public interface IPixRepositorio
    {
        public PixDTO consultaPix(Guid pix);
    }
}