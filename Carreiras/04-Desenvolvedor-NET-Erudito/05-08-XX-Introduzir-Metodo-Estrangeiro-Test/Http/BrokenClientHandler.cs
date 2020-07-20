using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _05_08_XX_Introduzir_Metodo_Estrangeiro_Test.Test.Http
{
    internal class BrokenClientHandler : HttpClientHandler
    {
        private readonly HttpStatusCode brokenHttpStatusCode;
        public BrokenClientHandler(HttpStatusCode brokenHttpStatusCode)
        {
            this.brokenHttpStatusCode = brokenHttpStatusCode;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Get)
            {
                if (request.RequestUri.PathAndQuery.Contains("/json/"))
                {
                    var response = new HttpResponseMessage(brokenHttpStatusCode);
                    return Task.FromResult(response);
                }
            }
            return (Task<HttpResponseMessage>)null;
        }
    }
}
