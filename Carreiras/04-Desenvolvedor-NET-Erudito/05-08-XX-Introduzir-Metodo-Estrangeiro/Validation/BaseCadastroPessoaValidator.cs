namespace _05_08_XX_Introduzir_Metodo_Estrangeiro.Validation
{
    public abstract class BaseCadastroPessoaValidator : BaseValidator
    {
        public BaseCadastroPessoaValidator(bool isFormatted) : base(isFormatted) { }

        protected override int GetDigitoVerificador(string documentSubstring)
        {
            int result = 0;
            int[] digitos = GetDigitos(documentSubstring);
            int subtracao = 
                GetComplementoDoModuloDe11(
                    GetSomaDosProdutos(
                        documentSubstring
                        , digitos
                        , GetMultiplicadores(digitos)));

            if (subtracao > 9)
                result = 0;
            else
                result = subtracao;
            return result;
        }
    }
}