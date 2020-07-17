using _04_03_XX_Memento.Memento;
using System;

namespace _04_03_XX_Memento
{
    public class Program
    {
        static void Main(string[] args)
        {
            Historico historico = new Historico();
            Contrato contrato = new Contrato(DateTime.Now, "Gabriel", TipoContrato.Novo);

            historico.Adiciona(contrato.SalvaEstado());

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            Console.WriteLine(contrato.Tipo);
            Console.WriteLine(historico.Pega(0).Contrato.Tipo);
            Console.WriteLine(historico.Pega(1).Contrato.Tipo);
            Console.WriteLine(historico.Pega(2).Contrato.Tipo);
            Console.ReadLine();
        }
    }
}

/**
 * Para que serve a classe Estado? Não poderíamos simplesmente guardar a classe Contrato de uma vez na lista?
 * Sim, poderíamos guardar diretamente a lista de Contratos. Mas veja que isso depende do problema. No nosso caso, não tínhamos outra informação para associar ao "estado". Se tivéssemos que armazenar, por exemplo, a data que o estado foi salvo, a classe Estado faria sentido.
 * 
 * As definições de padrões de projeto são geralmente as mais genéricas possíveis para dar suporte a qualquer problema. Mas você obviamente deve implementar o padrão de acordo com o seu problema.
 * 
 * Você consegue ver algum possível problema do padrão Memento? Se sim, qual?
 * Um possível problema é a quantidade de memória que ele pode ocupar, afinal estamos guardando muitas instâncias de objetos que podem ser pesados.
 * 
 * Por isso, dependendo do tamanho dos seus objetos, a classe Estado pode passar a guardar não o objeto todo, mas sim somente as propriedades que mais fazem sentido.
 * 
 * Nada impede você também de limitar a quantidade máxima de objetos no histórico que será armazenado.
 */
