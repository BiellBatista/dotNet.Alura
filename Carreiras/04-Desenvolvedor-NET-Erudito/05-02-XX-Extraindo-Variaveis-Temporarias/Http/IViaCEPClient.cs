using System.Threading.Tasks;

namespace _05_02_XX_Extraindo_Variaveis_Temporarias.Http
{
    public interface IViaCEPClient
    {
        string GetEndereco(string cep, string outputType);
        Task<string> GetEnderecoAsync(string cep, string outputType);
    }
}