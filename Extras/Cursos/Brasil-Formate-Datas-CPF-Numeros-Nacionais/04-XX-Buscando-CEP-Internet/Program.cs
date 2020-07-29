using Caelum.Stella.CSharp.Http;
using System.Diagnostics;
using System.Net.Http;

namespace _04_XX_Buscando_CEP_Internet
{
    class Program
    {
        static void Main(string[] args)
        {
            string cep = "01001000";
            string result = GetEndereco(cep);

            Debug.WriteLine(result);

            // extração do endereço no formato JSON
            ViaCEP viaCEP = new ViaCEP();
            string enderecoJson = viaCEP.GetEnderecoJson(cep);
            Debug.WriteLine(enderecoJson);

            // extração do endereço no formato XML
            string enderecoXml = viaCEP.GetEnderecoXml(cep);
            Debug.WriteLine(enderecoXml);

            // obtendo um resultado assíncrono
            var task = viaCEP.GetEnderecoJsonAsync(cep);
            Debug.WriteLine(task.Result);

            //pegar somente o logradouro e o bairro
            var endereco = viaCEP.GetEndereco(cep);
            Debug.WriteLine(string.Format("Logradouro: , Bairro: "));
            Debug.WriteLine(string.Format("Logradouro: {0}, Bairro: {1}", endereco.Logradouro, endereco.Bairro));
        }

        private static string GetEndereco(string cep)
        {
            string url = "https://viacep.com.br/ws/" + cep + "/json/";

            return new HttpClient().GetStringAsync(url).Result;
        }
    }
}
