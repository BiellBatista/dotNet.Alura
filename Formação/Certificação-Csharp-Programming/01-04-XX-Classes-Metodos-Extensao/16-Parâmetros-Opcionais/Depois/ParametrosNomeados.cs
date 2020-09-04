using System;

namespace _01_04_XX_Classes_Metodos_Extensao.Depois
{
    class ParametrosNomeados : IAulaItem
    {
        public void Executar()
        {
            //O método pode ser chamado do jeito normal, usando argumentos posicionais.
            ImprimirDetalhesDoPedido("Maria de Fátima", 31, "Caneca Vermelha");

            //Argumentos nomeados podem ser fornecidos para os parâmetros em qualquer ordem.
            ImprimirDetalhesDoPedido(nomeProduto: "Caneca Vermelha", vendedor: "Maria de Fátima", numeroPedido: 31);

            //Argumentos nomeados misturados com argumentos posicionais são válidos
            ImprimirDetalhesDoPedido("Maria de Fátima", 31, nomeProduto: "Caneca Vermelha");
            //Argumentos nomeados misturados com argumentos posicionais são válidos
            ImprimirDetalhesDoPedido("Maria de Fátima", 31, nomeProduto: "Caneca Vermelha");

            // As 2 linhas abaixo geravam erro de compilação ANTES DO C# 7.2:
            ImprimirDetalhesDoPedido(vendedor: "Maria de Fátima", 31, nomeProduto: "Caneca Vermelha");
            ImprimirDetalhesDoPedido("Maria de Fátima", numeroPedido: 31, "Caneca Vermelha");
        }

        void ImprimirDetalhesDoPedido(string vendedor, int numeroPedido, string nomeProduto)
        {
            if (string.IsNullOrWhiteSpace(vendedor))
            {
                throw new ArgumentException(message: "Nome de vendedor não pode ser nulo ou vazio.", paramName: nameof(vendedor));
            }

            Console.WriteLine($"Vendedor: {vendedor}, Pedido No.: {numeroPedido}, Produto: {nomeProduto}");
        }
    }
}
