using System.Threading.Tasks;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Http
{
    public interface IViaCEPClient
    {
        string GetEndereco(string cep, string outputType);
        Task<string> GetEnderecoAsync(string cep, string outputType);
    }
}