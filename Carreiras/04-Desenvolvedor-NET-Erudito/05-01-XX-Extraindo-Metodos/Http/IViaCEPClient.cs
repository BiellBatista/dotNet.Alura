using System.Threading.Tasks;

namespace _05_01_XX_Extraindo_Metodos.Http
{
    public interface IViaCEPClient
    {
        string GetEndereco(string cep, string outputType);
        Task<string> GetEnderecoAsync(string cep, string outputType);
    }
}