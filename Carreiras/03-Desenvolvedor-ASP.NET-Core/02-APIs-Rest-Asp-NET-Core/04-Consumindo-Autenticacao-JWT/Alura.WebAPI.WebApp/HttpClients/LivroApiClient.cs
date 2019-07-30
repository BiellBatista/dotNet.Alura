using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Seguranca;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Lista = Alura.ListaLeitura.Modelos.ListaLeitura;

namespace Alura.WebAPI.WebApp.HttpClients
{
    /**
     * Classe responsável por realizar os request na API
     */
    public class LivroApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly AuthApiClient _auth;

        public LivroApiClient(HttpClient httpClient, AuthApiClient auth)
        {
            _httpClient = httpClient;
            _auth = auth;
        }

        public async Task<LivroApi> GetLivroAsync(int id)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"livros/{id}");
            resposta.EnsureSuccessStatusCode();

            return await resposta.Content.ReadAsAsync<LivroApi>();
        }

        public async Task<byte[]> GetCapaLivroAsync(int id)
        {
            //_httpClient
            //    //adicionando o cabeçalho
            //    .DefaultRequestHeaders.Authorization =
            //        new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbiIsImp0aSI6IjgxMjAzOTU5LWM4ODItNDQ2NS05MzA0LTcyNzMwODRhZWM1YyIsImV4cCI6MTU2NDQ2MDM2MiwiaXNzIjoiQWx1cmEuV2ViQXBwIiwiYXVkIjoiUG9zdG1hbiJ9.PCPmiv0p1CUC0HGcgbuP_1EN4EjMp5NYNMrBRFq3utI");

            var token = await _auth.PostLoginAsync(new LoginModel { Login = "admin", Password = "123" });
            _httpClient
                .DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage resposta = await _httpClient.GetAsync($"livros/{id}/capa");
            resposta.EnsureSuccessStatusCode();

            return await resposta.Content.ReadAsByteArrayAsync();
        }

        public async Task DeleteLivroAsync(int id)
        {
            var resposta = await _httpClient.DeleteAsync($"livros/{id}");
            resposta.EnsureSuccessStatusCode();
        }

        public async Task<Lista> GetListaLeituraAsync(TipoListaLeitura tipo)
        {
            //não preciso mais disso, porque estou usando o AuthApiClient para me retornar o token
            //_httpClient
            //    //adicionando o cabeçalho
            //    .DefaultRequestHeaders.Authorization =
            //        new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbiIsImp0aSI6IjgxMjAzOTU5LWM4ODItNDQ2NS05MzA0LTcyNzMwODRhZWM1YyIsImV4cCI6MTU2NDQ2MDM2MiwiaXNzIjoiQWx1cmEuV2ViQXBwIiwiYXVkIjoiUG9zdG1hbiJ9.PCPmiv0p1CUC0HGcgbuP_1EN4EjMp5NYNMrBRFq3utI");

            var token = await _auth.PostLoginAsync(new LoginModel { Login = "admin", Password = "123" });
            _httpClient
                .DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

            var resposta = await _httpClient.GetAsync($"listasleitura/{tipo}");
            resposta.EnsureSuccessStatusCode(); //verificando se houve um status code da família 200
            return await resposta.Content.ReadAsAsync<Lista>();
        }

        public async Task PostLivroAsync(LivroUpload model)
        {
            HttpContent content = CreateMultipartFormDataContent(model);
            var resposta = await _httpClient.PostAsync("livros", content);
            resposta.EnsureSuccessStatusCode();
        }

        public async Task PutLivroAsync(LivroUpload model)
        {
            HttpContent content = CreateMultipartFormDataContent(model);
            var resposta = await _httpClient.PutAsync("livros", content);
            resposta.EnsureSuccessStatusCode();
        }

        private HttpContent CreateMultipartFormDataContent(LivroUpload model)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(model.Titulo), EnvolveComAspasDuplas("titulo"));
            content.Add(new StringContent(model.Lista.ParaString()), EnvolveComAspasDuplas("lista"));

            if (!string.IsNullOrEmpty(model.Subtitulo))
                content.Add(new StringContent(model.Subtitulo), EnvolveComAspasDuplas("subtitulo"));
            if (!string.IsNullOrEmpty(model.Resumo))
                content.Add(new StringContent(model.Resumo), EnvolveComAspasDuplas("resumo"));
            if (!string.IsNullOrEmpty(model.Autor))
                content.Add(new StringContent(model.Autor), EnvolveComAspasDuplas("autor"));
            if (model.Id > 0)
                content.Add(new StringContent(model.Id.ToString()), EnvolveComAspasDuplas("id"));

            if (model.Capa != null)
            {
                var imagemContent = new ByteArrayContent(model.Capa.ConvertToBytes());
                imagemContent.Headers.Add("content-type", "image/png");
                content.Add(
                    imagemContent,
                    EnvolveComAspasDuplas("capa"),
                    EnvolveComAspasDuplas("capa.png"));
            }

            return content;
        }

        private string EnvolveComAspasDuplas(string valor)
        {
            return $"\"{valor}\"";
        }
    }
}
