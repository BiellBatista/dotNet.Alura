using Caelum.Stella.CSharp.Validation;
using System;
using System.Diagnostics;

namespace _01_XX_Validacao_Formatacao
{
    class Program
    {
        static void Main(string[] args)
        {
            string cpf1 = "86288366757";
            string cpf2 = "98745366797";
            string cpf3 = "22222222222";

            ValidarCPF(cpf1);
            ValidarCPF(cpf2);
            ValidarCPF(cpf3);
        }

        private static void ValidarCPF(string cpf)
        {
            try
            {
                new CPFValidator().AssertValid(cpf);
                Debug.WriteLine("CPF válido: " + cpf);
            }
            catch (Exception exc)
            {
                Debug.WriteLine("CPF inválido: " + cpf + " : " + exc.ToString());
            }
        }
    }
}
