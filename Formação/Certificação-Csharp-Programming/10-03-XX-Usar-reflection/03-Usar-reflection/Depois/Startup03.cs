using System;
using System.Linq;
using System.Reflection;

namespace _10_03_XX_Usar_reflection.Depois
{
    //Criar e aplicar atributos
    public class Startup03 : IAulaItem
    {
        public void Executar()
        {
            Relatorio03 relatorio = new Relatorio03("Relatório de Vendas");
            relatorio.Imprimir();

            Console.WriteLine();

            if (Attribute.IsDefined(typeof(Venda03), typeof(SerializableAttribute)))
            {
                Console.WriteLine("A classe Venda DEFINE o atributo Serializable");
            }
            else
            {
                Console.WriteLine("A classe Venda NÃO DEFINE o atributo Serializable");
            }

            Console.WriteLine();

            //TAREFA 1:
            Console.WriteLine("OBTENDO O TIPO DO RELATÓRIO");
            Console.WriteLine("===========================");

            Type tipo = relatorio.GetType();
            Console.WriteLine(tipo);

            //TAREFA 2:
            Console.WriteLine();
            Console.WriteLine("OBTENDO OS MEMBROS DO RELATÓRIO");
            Console.WriteLine("===============================");

            MemberInfo[] membros = tipo.GetMembers();

            foreach (var membro in membros)
            {
                Console.WriteLine(membro.ToString());
            }

            //TAREFA 3:
            Console.WriteLine();
            Console.WriteLine("MODIFICANDO NOME VIA REFLECTION");
            Console.WriteLine("===============================");

            relatorio.Nome = "NOME MODIFICADO!";
            relatorio.Imprimir();

            MethodInfo methodInfo = tipo.GetMethod("set_Nome");

            methodInfo.Invoke(relatorio, new object[] { "NOME MODIFICADO VIA REFLECTION!" });
            relatorio.Imprimir();

            //TAREFA 4:
            Console.WriteLine();
            Console.WriteLine("TIPOS DO ASSEMBLY");
            Console.WriteLine("QUE IMPLEMENTAM A INTERFACE IRelatorio");
            Console.WriteLine("======================================");

            Assembly esteAssembly = Assembly.GetExecutingAssembly();

            var tipos = esteAssembly.GetTypes();

            foreach (var tipoAssembly in tipos)
            {
                if (tipoAssembly.IsInterface)
                {
                    continue;
                }

                if (typeof(IRelatorio03).IsAssignableFrom(tipoAssembly))
                {
                    Console.WriteLine(tipoAssembly);
                }
            }

            //TAREFA 5:
            Console.WriteLine();
            Console.WriteLine("USANDO LINQ PARA VER TIPOS DO ASSEMBLY");
            Console.WriteLine("QUE IMPLEMENTAM A INTERFACE IRelatorio");
            Console.WriteLine("======================================");

            var consulta = from t in tipos
                           where typeof(IRelatorio03).IsAssignableFrom(t)
                            && !t.IsInterface
                           select t;

            foreach (var tipoConsulta in consulta)
            {
                Console.WriteLine(tipoConsulta.ToString());
            }

            Console.ReadLine();
        }
    }
}