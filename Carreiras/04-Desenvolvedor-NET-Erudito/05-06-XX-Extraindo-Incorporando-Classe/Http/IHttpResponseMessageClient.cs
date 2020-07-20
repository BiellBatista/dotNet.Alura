using System.Net.Http;
using System.Threading.Tasks;

namespace _05_06_XX_Extraindo_Incorporando_Classe.Http
{
    public interface IHttpResponseMessageClient
    {
        Task<HttpResponseMessage> GetHttpResponseMessage(string url);
        HttpResponseMessage GetHttpResponseMessageAsync(string url);
    }
}