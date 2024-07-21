namespace _02_XX_Lendo_Objetos_Dinamicamente.Common
{
    public class LeitorDeBoleto
    {
        public List<Boleto> LerBoletos(string caminhoArquivo)
        {
            //throw new NotImplementedException();

            // montar lista de boletos
            var boletos = new List<Boleto>();

            // ler arquivo de boletos
            using (var reader = new StreamReader(caminhoArquivo))
            {
                // ler cabeçalho do arquivo CSV
                var linha = reader.ReadLine();
                var cabecalho = linha.Split(',');

                // para cada linha do arquivo CSV
                while (!reader.EndOfStream)
                {
                    // ler dados
                    linha = reader.ReadLine();
                    var dados = linha.Split(',');

                    // carregar objeto Boleto
                    var boleto = MapearTextoParaObjeto<Boleto>(cabecalho, dados);

                    // adicionar boleto à lista
                    boletos.Add(boleto);
                }
            }

            // retornar lista de boletos
            return boletos;
        }

        private static Boleto MapearTextoParaBoleto(string[] nomesPropriedades, string[] valoresPropriedades)
        {
            var instancia = new Boleto
            {
                CedenteNome = valoresPropriedades[0],
                CedenteCpfCnpj = valoresPropriedades[1],
                CedenteAgencia = valoresPropriedades[2],
                CedenteConta = valoresPropriedades[3],
                SacadoNome = valoresPropriedades[4],
                SacadoCpfCnpj = valoresPropriedades[5],
                SacadoEndereco = valoresPropriedades[6],
                Valor = Convert.ToDecimal(valoresPropriedades[7]),
                DataVencimento = Convert.ToDateTime(valoresPropriedades[8]),
                NumeroDocumento = valoresPropriedades[9],
                NossoNumero = valoresPropriedades[10],
                CodigoBarras = valoresPropriedades[11],
                LinhaDigitavel = valoresPropriedades[12]
            };

            return instancia;
        }

        private static T MapearTextoParaObjeto<T>(string[] nomesPropriedades, string[] valoresPropriedades)
        {
            // criando uma instância dinâmica de uma classe
            T instancia = Activator.CreateInstance<T>();

            // percorre os nomes de propriedades.
            for (var i = 0; i < nomesPropriedades.Length; i++)
            {
                // obtém a propriedade atual através do nome.
                var nomePropriedade = nomesPropriedades[i];
                var propertyInfo = instancia.GetType().GetProperty(nomePropriedade);

                // verifica se a propriedade foi encontrada.
                if (propertyInfo != null)
                {
                    // obtém o tipo da propriedade.
                    var propertyType = propertyInfo.PropertyType;

                    // obtém o valor da propriedade.
                    var valor = valoresPropriedades[i];

                    // converte o valor da propriedade para o tipo correto.
                    var valorConvertido = Convert.ChangeType(valor, propertyType);

                    // guarda o valor convertido na propriedade.
                    propertyInfo.SetValue(instancia, valorConvertido);
                }
            }

            return instancia;
        }
    }
}