using System.Threading.Tasks;

namespace _05_04_XX_Substituindo_Metodo.Http
{
    public interface IViaCEPClient
    {
        string GetEndereco(string cep, string outputType);
        Task<string> GetEnderecoAsync(string cep, string outputType);
    }
}