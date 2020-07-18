using _04_08_XX_Adapter.Adapter;
using System;

namespace _04_08_XX_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "victor";
            cliente.Endereco = "Rua Vergueiro";
            cliente.DataDeNascimento = DateTime.Now;

            GeradorDeXml gerador = new GeradorDeXml();
            String xml = gerador.GeraXml(cliente);

            Console.ReadLine();
        }
    }
}

/**
 * Adapter e outros padrões de projeto
 * Veja que a implementação do Adapter é muito parecida com a implementação do Command e do Strategy, a diferença está realmente no propósito do padrão, o problema que está sendo resolvido.
 * 
 * Command é utilizado quando queremos guardar um bloco de código que será executado posteriormente, como feito no exemplo da fila de trabalho implementada anteriormente.
 * 
 * No Strategy estamos tentando implementar uma estratégia diferente para resolver um determinado problema que temos no código. Por exemplo, imagine que a aplicação precisa enviar buscas para diversos bancos de dados diferentes, nesse caso, o código que será executado em cada banco de dados será levemente diferente, mas o propósito é o mesmo: Fazer o acesso aos dados.
 * 
 * Já no Adapter, nós temos uma biblioteca ou um sistema antigo cuja interface não se encaixa perfeitamente no sistema atual, nesse caso, podemos adaptar essa interface definida pela biblioteca ou sistema legado utilizando uma nova classe dentro de nosso sistema. Esse é um propósito bem diferente do que o dos outros padrões.
 * 
 * Adapter e Strategy
 * A diferença que existe entre os padrões é o propósito. No Adapter estamos adaptando a interface de um sistema antigo para que ela possa se encaixar em um sistema novo. Já no Strategy a ideia é utilizar diferentes estratégias para resolver um dado problema no sistema.
 * 
 * Adapter e Command
 * Como dito no exercício anterior, o Adapter serve para adaptar o código de um sistema legado ou biblioteca para que ele possa ser utilizado no novo sistema. Já o command serve para guardarmos um trecho de código que precisa ser executado posteriormente.
 */
