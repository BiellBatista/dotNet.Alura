﻿using _05_02_XX_Extraindo_Variaveis_Temporarias.Inwords;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _05_02_XX_Extraindo_Variaveis_Temporarias.Vault
{
    public static class MoneyExtensions
    {
        public static string Extenso(this Money money)
        {
            switch(money.CurrencyInfo.DisplayCulture.NumberFormat.CurrencySymbol)
            {
                case "R$":
                    return new MoedaBRL(money).Extenso();
                case "$":
                    return new MoedaUSD(money).Extenso();
                case "€":
                    return new MoedaEUR(money).Extenso();
                default:
                    throw new ArgumentException(money.CurrencyInfo.DisplayCulture.NumberFormat.CurrencySymbol + " currency symbol is not supported");
            }
        }
    }
}
