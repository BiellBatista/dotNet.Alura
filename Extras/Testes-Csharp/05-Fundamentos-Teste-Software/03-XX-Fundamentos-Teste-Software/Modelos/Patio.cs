namespace _03_XX_Fundamentos_Teste_Software.Modelos
{
    public class Patio
    {
        private double faturado;
        public double Faturado { get => faturado; set => faturado = value; }

        private List<Veiculo> veiculos;
        public List<Veiculo> Veiculos { get => veiculos; set => veiculos = value; }

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
    }
}