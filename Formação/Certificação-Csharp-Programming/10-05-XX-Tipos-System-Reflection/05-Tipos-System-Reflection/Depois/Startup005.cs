using _10_05_XX_Tipos_System_Reflection.Depois.Modelo;
using System;

namespace _10_05_XX_Tipos_System_Reflection.Depois
{
    public class Startup005 : IAulaItem
    {
        public void Executar()
        {
            //TAREFA 1: obter as propriedades de CarrinhoCliente
            //TAREFA 2: descobrir se podem ler ou escrever
            //TAREFA 3: descobrir seus acessadores getters e setters

            var tipo = typeof(CarrinhoCliente);
            var propriedades = tipo.GetProperties();

            foreach (var propriedade in propriedades)
            {
                Console.WriteLine("Propriedade: {0}", propriedade.Name);

                if (propriedade.CanRead)
                {
                    Console.WriteLine("\tPode ler");
                    Console.WriteLine("\t\tMétodo get: {0}", propriedade.GetMethod);
                }

                if (propriedade.CanWrite)
                {
                    Console.WriteLine("\tPode escrever");
                    Console.WriteLine("\t\tMétodo set: {0}", propriedade.SetMethod);
                }
            }

            Console.ReadLine();
        }
    }
}