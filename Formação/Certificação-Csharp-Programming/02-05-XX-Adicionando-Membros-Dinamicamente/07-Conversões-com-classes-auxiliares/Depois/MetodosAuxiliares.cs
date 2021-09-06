﻿using System;
using System.Globalization;

namespace _02_05_XX_Adicionando_Membros_Dinamicamente.Depois
{
    internal class MetodosAuxiliares : IAulaItem
    {
        public void Executar()
        {
            string textoDigitado = "123";
            int numeroConvertido = int.Parse(textoDigitado);
            Console.WriteLine(numeroConvertido);

            textoDigitado = "abc";
            int.TryParse(textoDigitado, out numeroConvertido);

            if (int.TryParse(textoDigitado, out numeroConvertido))
            {
                Console.WriteLine(numeroConvertido);
            }
            else
            {
                Console.WriteLine("texto não é um numero");
            }

            textoDigitado = "123.45";

            decimal.TryParse(textoDigitado,
                NumberStyles.Currency, //moeda
                CultureInfo.CurrentCulture, //pt-BR
                out decimal valorConvertido
                );
            Console.WriteLine(valorConvertido);
        }
    }
}