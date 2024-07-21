namespace _01_XX_Preenchendo_Objetos_Dinamicamente.Common
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
                string linha = reader.ReadLine();
                string[] cabecalho = linha.Split(',');

                // para cada linha do arquivo CSV
                while (!reader.EndOfStream)
                {
                    // ler dados
                    linha = reader.ReadLine();
                    string[] dados = linha.Split(',');

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

            //instancia.CedenteNome = valoresPropriedades[0];
            //instancia.CedenteCpfCnpj = valoresPropriedades[1];
            //instancia.CedenteAgencia = valoresPropriedades[2];
            //instancia.CedenteConta = valoresPropriedades[3];
            //instancia.SacadoNome = valoresPropriedades[4];
            //instancia.SacadoCpfCnpj = valoresPropriedades[5];
            //instancia.SacadoEndereco = valoresPropriedades[6];
            //instancia.Valor = Convert.ToDecimal(valoresPropriedades[7]);
            //instancia.DataVencimento = Convert.ToDateTime(valoresPropriedades[8]);
            //instancia.NumeroDocumento = valoresPropriedades[9];
            //instancia.NossoNumero = valoresPropriedades[10];
            //instancia.CodigoBarras = valoresPropriedades[11];
            //instancia.LinhaDigitavel = valoresPropriedades[12];

            return instancia;
        }
    }
}