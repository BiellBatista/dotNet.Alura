using System.Threading.Tasks;

namespace _05_06_XX_Extraindo_Incorporando_Classe.Http
{
    public interface IViaCEPClient
    {
        string GetEndereco(string cep, string outputType);
        Task<string> GetEnderecoAsync(string cep, string outputType);
    }
}