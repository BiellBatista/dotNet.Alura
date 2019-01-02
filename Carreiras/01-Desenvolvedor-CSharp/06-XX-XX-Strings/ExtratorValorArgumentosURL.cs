using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_XX_XX_Strings
{
    public class ExtratorValorArgumentosURL
    {
        private readonly string _argumentos;
        public string URL { get; }

        public ExtratorValorArgumentosURL(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("O argumento URL não pode ser nujll ou uma string vazia", nameof(url));

            URL = url;

            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao + 1);
        }

        // moedaOrigem=real&moedaDestino=dolar
        public string GetValor(string nomeParametro)
        {
            string termo = nomeParametro + "=";
            int indiceTermo = _argumentos.IndexOf(termo);

            return _argumentos.Substring(indiceTermo + termo.Length);
        }
    }
}
