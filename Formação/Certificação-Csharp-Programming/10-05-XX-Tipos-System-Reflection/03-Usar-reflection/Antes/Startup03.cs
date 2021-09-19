using System;

namespace _10_05_XX_Tipos_System_Reflection.Antes
{
    //Criar e aplicar atributos
    public class Startup03 : IAulaItem
    {
        public void Executar()
        {
            //Tarefa: Ler os atributos de formato
            //de impressão da classe Venda

            Relatorio03 relatorio = new Relatorio03("Relatório de Vendas");
            relatorio.Imprimir();

            if (Attribute.IsDefined(typeof(Venda03), typeof(SerializableAttribute)))
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