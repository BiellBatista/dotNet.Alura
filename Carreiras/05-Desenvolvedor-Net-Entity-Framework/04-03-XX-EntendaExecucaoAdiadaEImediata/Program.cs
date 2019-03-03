using _04_03_XX_EntendaExecucaoAdiadaEImediata.Data;
using System;
using System.Linq;

namespace _04_03_XX_EntendaExecucaoAdiadaEImediata
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraTunesEntities())
            {
                var mesAniversario = 1;

                while (mesAniversario <= 12)
                {

                    Console.WriteLine("Mês: {0}", mesAniversario);

                    // esta consulta é uma árvore de expressão e só gerar executar dentro do laço for
                    //var query = from f in contexto.Funcionarios
                    //            where f.DataNascimento.Value.Month == mesAniversario
                    //            orderby f.DataNascimento.Value.Month, f.DataNascimento.Value.Day
                    //            select f;
                    // esta execução é conhecida como Execucao tardia

                    // executando a query assim que a mesma é definida, por causa do método ToList(). Porém, o resultado fica na memória.
                    // esta execução é conhecida como Execucao imediata
                    var lista = (from f in contexto.Funcionarios
                                where f.DataNascimento.Value.Month == mesAniversario
                                orderby f.DataNascimento.Value.Month, f.DataNascimento.Value.Day
                                select f).ToList();

                    mesAniversario++;

                    // A consulta é executa apenas no laço foreach
                    foreach (var f in lista)
                        //{0:dd/MM} serve para formatar a data
                        Console.WriteLine("{0:dd/MM}\t{1}\t{2}", f.DataNascimento, f.PrimeiroNome, f.Sobrenome);
                }
            }
        }
    }
}
