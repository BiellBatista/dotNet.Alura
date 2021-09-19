using System;

namespace _10_02_XX_Ler_atributos.Depois
{
    //Criar e aplicar atributos
    public class Startup02 : IAulaItem
    {
        public void Executar()
        {
            //Tarefa: Ler os atributos de formato
            //de impressão da classe Venda

            Relatorio02 relatorio = new Relatorio02("Relatório de Vendas");
            relatorio.Imprimir();

            if (Attribute.IsDefined(typeof(Venda02), typeof(SerializableAttribute)))
            {
                Console.WriteLine("A classe Venda DEFINE o atributo Serializable");
            }
            else
            {
                Console.WriteLine("A classe Venda NÃO DEFINE o atributo Serializable");
            }

            Console.ReadLine();
        }
    }
}