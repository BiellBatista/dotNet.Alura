using Caelum.Stella.CSharp.Validation;
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

            string cnpj1 = "51241758000152";
            string cnpj2 = "14128481000120";

            ValidarCNPJ(cnpj1);
            ValidarCNPJ(cnpj2);

            string titulo1 = "041372570132";
            string titulo2 = "774387480132";

            ValidarTitulo(titulo1);
            ValidarTitulo(titulo2);
        }

        private static void ValidarCPF(string cpf)
        {
            //try
            //{
            //    new CPFValidator().AssertValid(cpf);
            //    Debug.WriteLine("CPF válido: " + cpf);
            //}
            //catch (Exception exc)
            //{
            //    Debug.WriteLine("CPF inválido: " + cpf + " : " + exc.ToString());
            //}
            // a opção de baixo é mais elegante que o try catch e menos custosa
            if (new CPFValidator().IsValid(cpf))
            {
                Debug.WriteLine("CPF válido: " + cpf);
            }
            else
            {
                Debug.WriteLine("CPF inválido: " + cpf);
            }
        }

        private static void ValidarCNPJ(string cnpj)
        {
            if (new CNPJValidator().IsValid(cnpj))
            {
                Debug.WriteLine("CNPJ válido: " + cnpj);
            }
            else
            {
                Debug.WriteLine("CNPJ inválido: " + cnpj);
            }
        }

        private static void ValidarTitulo(string titulo)
        {
            if (new TituloEleitoralValidator().IsValid(titulo))
            {
                Debug.WriteLine("Título válido: " + titulo);
            }
            else
            {
                Debug.WriteLine("Título inválido: " + titulo);
            }
        }
    }
}
