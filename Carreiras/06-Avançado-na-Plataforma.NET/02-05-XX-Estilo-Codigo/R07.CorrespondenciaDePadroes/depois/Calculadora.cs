using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _02_05_XX_Estilo_Codigo.R07.depois
{
    class MenuItem : _02_05_XX_Estilo_Codigo.MenuItem
    {
        public override void Main()
        {
            Console.WriteLine("Calculadora Para Somar Qualquer Tipo");
            Console.WriteLine("====================================");
            Console.WriteLine();

            var calculadora = new Calculadora();
            calculadora.Somar(2); //int
            calculadora.Somar(3.0m); //decimal
            calculadora.Somar(3.0); //double
            calculadora.Somar(new int[] { 4, 5, 6 });
            calculadora.Somar(new decimal[] { 4.1m, 5.2m, 6.3m });
            calculadora.Somar(new double[] { 4.1, 5.2, 6.3 });
            calculadora.Somar("20");
            calculadora.Somar("R$ 20");
            calculadora.Somar("[20]");
            calculadora.Somar(new object[] { "20", 100, 150m, 24.0, "R$ 12,34" });
        }
    }

    class Calculadora
    {
        private const string NUMERO_ENTRE_COLCHETES = @"\[(\d+)\]";

        public double Soma { get; private set; } = 0d;

        public void Somar(object parametro)
        {
            var cultura = System.Globalization.CultureInfo.CurrentCulture;

            switch (parametro)
            {
                // tentando converter o parametro para double, caso sucesso, atribua o resulta na variável valorDouble e entra no case
                case double valorDouble:
                    Console.WriteLine($"Total anterior: {Soma}");
                    Console.WriteLine($"Somando: {valorDouble}");
                    Soma += valorDouble;
                    Console.WriteLine($"Total atual: {Soma}");
                    Console.WriteLine();
                    break;
                // tentando converter o parametro para int, caso sucesso, atribua o resulta na variável valorInt e entra no case
                case int valorInt:
                    Somar((double)valorInt);
                    break;
                // tentando converter o parametro para decimal, caso sucesso, atribua o resulta na variável valorDecimal e entra no case
                case decimal valorDecimal:
                    Somar((double)valorDecimal);
                    break;
                // tentando converter o parametro para string, caso sucesso, atribua o resulta na variável str e entra no case
                case string str
                    when (Regex.Match(str, NUMERO_ENTRE_COLCHETES).Success): //verificando se o valor da string bate com o regex, caso sim entre, caso não passe
                    {
                        Somar(Regex.Match(str, NUMERO_ENTRE_COLCHETES).Groups[1].Value);
                    }
                    break;
                case string str
                    when (double.TryParse(parametro.ToString(), NumberStyles.Currency, cultura.NumberFormat, out double valorDouble)): //verificando se o valor da string bate com o regex, caso sim entre, caso não passe
                    {
                        Somar(valorDouble);
                    }
                    break;
                // tentando converter o parametro para IEnumerable<object>, caso sucesso, atribua o resulta na variável colecao e entra no case
                case IEnumerable<object> colecao:
                    foreach (var item in colecao) Somar(item);
                    break;
                // tentando converter o parametro para IEnumerable<int>, caso sucesso, atribua o resulta na variável colecao e entra no case
                case IEnumerable<int> colecao:
                    foreach (var item in colecao) Somar(item);
                    break;
                // tentando converter o parametro para IEnumerable<decimal>, caso sucesso, atribua o resulta na variável colecao e entra no case
                case IEnumerable<decimal> colecao:
                    foreach (var item in colecao) Somar(item);
                    break;
                // tentando converter o parametro para IEnumerable<double>, caso sucesso, atribua o resulta na variável colecao e entra no case
                case IEnumerable<double> colecao:
                    foreach (var item in colecao) Somar(item);
                    break;
                default:
                    break;
            }
        }
    }
}
