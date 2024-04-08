using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace _04_05_XX_Classificacao_Artistas.Web.Services;

public class CookieHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        return base.SendAsync(request, cancellationToken);
    }
}