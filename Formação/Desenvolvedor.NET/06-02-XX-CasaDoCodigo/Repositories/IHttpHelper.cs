using _06_02_XX_CasaDoCodigo.Models;
using Microsoft.Extensions.Configuration;

namespace _06_02_XX_CasaDoCodigo
{
    public interface IHttpHelper
    {
        IConfiguration Configuration { get; }
        int? GetPedidoId();
        void SetPedidoId(int pedidoId);
        void ResetPedidoId();
        void SetCadastro(Cadastro cadastro);
        Cadastro GetCadastro();
    }
}