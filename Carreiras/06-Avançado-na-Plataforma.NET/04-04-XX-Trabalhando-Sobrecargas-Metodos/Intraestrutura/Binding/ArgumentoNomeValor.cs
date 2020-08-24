using System;

namespace _04_04_XX_Trabalhando_Sobrecargas_Metodos.Intraestrutura.Binding
{
    public class ArgumentoNomeValor
    {


        public string Nome { get; private set; }
        public string Valor { get; private set; }

        public ArgumentoNomeValor(string nome, string valor)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Valor = valor ?? throw new ArgumentNullException(nameof(nome));
        }
    }
}
