using System.Threading.Tasks;

namespace _05_05_XX_Movendo_Metodo_Campo.Http
{
    public interface IViaCEPClient
    {
        string GetEndereco(string cep, string outputType);
        Task<string> GetEnderecoAsync(string cep, string outputType);
    }
}