using _04_XX_CI_CD_Azure_DevOps.Data.Tests.Servicos.DTO;

namespace _04_XX_CI_CD_Azure_DevOps.Data.Tests.Servicos
{
    public interface IPixRepositorio
    {
        public PixDTO consultaPix(Guid pix);
    }
}