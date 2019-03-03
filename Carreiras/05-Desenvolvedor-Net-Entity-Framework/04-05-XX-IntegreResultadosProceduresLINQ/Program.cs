using _04_05_XX_IntegreResultadosProceduresLINQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_05_XX_IntegreResultadosProceduresLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var clienteId = 17;
            /*
             * Após adicionar a stored procedure no banco de dados, devo atualizar o meu modelo do Entity Framework
             */
            using (var contexto = new AluraTunesEntities())
            {
                var vendasPorCliente = from v in contexto.ps_Itens_Por_Cliente(clienteId)
                                       /*
                                        * para agrupar por dois valores, devo utilizar objeto anonimo 
                                        */
                                       group v by new
                                       {
                                           v.DataNotaFiscal.Year,
                                           v.DataNotaFiscal.Month
                                       }
                                       into agrupado // armazenando o agrupamento na variável
                                       orderby agrupado.Key.Year, agrupado.Key.Month // acessando a chave doa grupamento para pegar os valores
                                       select new
                                       {
                                           Ano = agrupado.Key.Year,
                                           Mes = agrupado.Key.Month,
                                           Total = agrupado.Sum(a => a.Total)
                                       };

                foreach (var item in vendasPorCliente)
                    Console.WriteLine("{0}\t{1}\t{2}", item.Ano, item.Mes, item.Total);
            }
        }
    }
}
/*
 * Considere a seguinte classe C#:
public class Aluno
{
    public string Escola { get; set; }
    public string Curso { get; set; }
    public string AnoLetivo { get; set; }
    public string Nome { get; set; }
}
 *Agora imagine uma consulta LINQ to objects utilizando uma lista de objetos da class Aluno:
var alunosQuery =
from a in alunos
select new
{
    Escola = a.Escola,
    Curso = a.Curso,
    AnoLetivo = a.AnoLetivo,
    Nome = a.Nome
};
 * Desenvolva uma nova consulta LINQ sobre a mesma lista de alunos, que traga um resultado agregado, contendo:
 * O nome da escola,
 * O nome do curso,
 * O ano letivo,
 * Uma lista dos alunos que frequentam a mesma escola, no mesmo curso, no mesmo ano letivo
 * Podemos agrupar a lista de alunos por um objeto de tipo anônimo, onde os 3 campos a serem agrupados são propriedades desse objeto anônimo. Em seguida, podemos modificar a cláusula select para trazer outro objeto de tipo anônimo, trazendo as propriedades agrupadas (Escola, Curso, AnoLetivo) e também uma nova propriedade com a lista dos alunos que frequentam a mesma escola, o mesmo curso e o mesmo ano letivo.
var alunosAgrupados =
        from a in alunos
        group a by new
        {
            a.Escola,
            a.Curso,
            a.AnoLetivo
        } into agrupado
        select new
        {
            Escola = agrupado.Key.Escola,
            Curso = agrupado.Key.Curso,
            AnoLetivo = agrupado.Key.AnoLetivo,
            Alunos = agrupado.ToList(),
        };
 */
