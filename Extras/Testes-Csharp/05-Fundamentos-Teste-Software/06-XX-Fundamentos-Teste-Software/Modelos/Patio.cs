namespace _06_XX_Fundamentos_Teste_Software.Modelos
{
    public class Patio
    {
        private Operador _operadorPatio;

        private double faturado;
        public double Faturado { get => faturado; set => faturado = value; }

        private List<Veiculo> veiculos;
        public List<Veiculo> Veiculos { get => veiculos; set => veiculos = value; }

        public Operador OperadorPatio { get => _operadorPatio; set => _operadorPatio = value; }

        public Patio()
        {
            Faturado = 0;
            veiculos = new List<Veiculo>();
        }

        public double TotalFaturado()
        {
            return Faturado;
        }

        public string MostrarFaturamento()
        {
            string totalfaturado = String.Format("Total faturado até o momento :::::::::::::::::::::::::::: {0:c}", this.TotalFaturado());

            return totalfaturado;
        }

        public void RegistrarEntradaVeiculo(Veiculo veiculo)
        {
            veiculo.HoraEntrada = DateTime.Now;
            veiculo.Ticket = GerarTicket(veiculo);

            Veiculos.Add(veiculo);
        }

        public string RegistrarSaidaVeiculo(String placa)
        {
            Veiculo? procurado = null;
            string informacao = string.Empty;

            foreach (Veiculo v in Veiculos)
            {
                if (v.Placa == placa)
                {
                    v.HoraSaida = DateTime.Now;
                    TimeSpan tempoPermanencia = v.HoraSaida - v.HoraEntrada;
                    double valorASerCobrado = 0;

                    if (v.Tipo is TipoVeiculo.Automovel)
                    {
                        /// o método Math.Ceiling(), aplica o conceito de teto da matemática onde o valor máximo é o inteiro imediatamente posterior a ele.
                        /// Ex.: 0,9999 ou 0,0001 teto = 1
                        /// Obs.: o conceito de chão é inverso e podemos utilizar Math.Floor();
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 2;
                    }
                    if (v.Tipo is TipoVeiculo.Motocicleta)
                    {
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 1;
                    }

                    informacao = string.Format(" Hora de entrada: {0: HH: mm: ss}\n " +
                                             "Hora de saída: {1: HH:mm:ss}\n " +
                                             "Permanência: {2: HH:mm:ss} \n " +
                                             "Valor a pagar: {3:c}", v.HoraEntrada, v.HoraSaida, new DateTime().Add(tempoPermanencia), valorASerCobrado);
                    procurado = v;
                    Faturado = Faturado + valorASerCobrado;

                    break;
                }
            }

            if (procurado is not null)
            {
                Veiculos.Remove(procurado);
            }
            else
            {
                return "Não encontrado veículo com a placa informada.";
            }

            return informacao;
        }

        public Veiculo PesquisaVeiculo(string idTicket)
        {
            // Como estamos trabalhando com array de objetos,
            // Podemos utilizar os recursos do `Linq to Objetcs` do .NET
            var encontrado = (from veiculo in Veiculos
                              where veiculo.IdTicket == idTicket
                              select veiculo).SingleOrDefault();

            return encontrado;
        }

        public Veiculo AlterarDadosVeiculo(Veiculo veiculoAlterado)
        {
            // Como estamos trabalhando com array de objetos,
            // Podemos utilizar os recursos do `Linq to Objetcs` do .NET
            var veiculoTemp = (from veiculo in this.Veiculos
                               where veiculo.Placa == veiculoAlterado.Placa
                               select veiculo).SingleOrDefault();

            veiculoTemp.AlterarDados(veiculoAlterado);

            return veiculoTemp;
        }

        private string GerarTicket(Veiculo veiculo)
        {
            // Vamos criar um Id aletório para o Ticket usando a Classe GUID e vamos padronizar com o tamanho de 6 caracteres.
            string identificador = new Guid().ToString().Substring(0, 5);
            string ticket = "### Ticket Estacionamento Alura ###" +
                           $">>> Identificador: {identificador}" +
                           $">>> Data/Hora de Entrada: {DateTime.Now}" +
                           $">>> Placa Veículo: {veiculo.Placa}" +
                           $">>> Operador: {_operadorPatio.Matricula}";

            veiculo.IdTicket = identificador;
            veiculo.Ticket = ticket;

            return ticket;
        }
    }
}