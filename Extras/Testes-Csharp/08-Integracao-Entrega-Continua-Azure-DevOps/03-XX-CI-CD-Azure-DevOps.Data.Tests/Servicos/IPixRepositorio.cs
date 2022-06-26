using _03_XX_CI_CD_Azure_DevOps.Data.Tests.Servicos.DTO;

namespace _03_XX_CI_CD_Azure_DevOps.Data.Tests.Servicos
{
    public interface IPixRepositorio
    {
        public PixDTO consultaPix(Guid pix);
    }
}