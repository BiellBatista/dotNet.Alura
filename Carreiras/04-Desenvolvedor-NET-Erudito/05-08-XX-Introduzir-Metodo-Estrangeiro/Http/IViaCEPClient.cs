using System.Threading.Tasks;

namespace _05_08_XX_Introduzir_Metodo_Estrangeiro.Http
{
    public interface IViaCEPClient
    {
        string GetEndereco(string cep, string outputType);
        Task<string> GetEnderecoAsync(string cep, string outputType);
    }
}