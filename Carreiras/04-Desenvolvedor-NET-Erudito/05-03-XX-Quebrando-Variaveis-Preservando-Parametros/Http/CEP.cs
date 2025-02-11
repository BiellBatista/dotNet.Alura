﻿using _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Http.Exceptions;
using _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Validation;
using System;
using System.Text.RegularExpressions;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Http
{
    public class CEP : IComparable<CEP>, IEquatable<CEP>
    {
        protected static string RegexFormatted => DocumentFormats.CEP;
        protected static string RegexUnformatted => DocumentFormats.CEPDigitsOnly;

        private readonly string cepAsString;

        public CEP() : this(null) { }

        public CEP(string cepAsString)
        {
            if (cepAsString == null)
                this.cepAsString = null;
            else if (Regex.IsMatch(cepAsString, RegexFormatted))
                this.cepAsString = UnformatCEP(cepAsString);
            else if (new Regex(RegexUnformatted).IsMatch(cepAsString))
                this.cepAsString = cepAsString;
            else
                throw new InvalidZipCodeFormat();
        }

        private static string UnformatCEP(string cepAsString)
        {
            return cepAsString.Replace("-", "");
        }

        public bool IsNull => string.IsNullOrEmpty(cepAsString);

        public int CompareTo(CEP other)
        {
            return this.cepAsString.CompareTo(other);
        }

        public override int GetHashCode()
        {
            return cepAsString.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.cepAsString.Equals((CEP)obj);
        }

        public bool Equals(CEP other)
        {
            return this.cepAsString.Equals(other);
        }

        public static implicit operator string(CEP cep) => cep.cepAsString;
        public static implicit operator CEP(string cepAsString) => new CEP(cepAsString);
    }
}
