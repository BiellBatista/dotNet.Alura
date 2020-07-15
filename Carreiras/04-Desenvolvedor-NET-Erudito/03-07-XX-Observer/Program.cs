using System;

namespace _03_07_XX_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            NotaFiscalBuilder builder = new NotaFiscalBuilder();
            builder.AdicionaAcao(new EnviadorDeEmail());
            builder.AdicionaAcao(new NotaFiscalDao());
            builder.AdicionaAcao(new EnviadorDeSms());
            builder.AdicionaAcao(new Impressora());
            builder.AdicionaAcao(new Multiplicador(2));
            builder.AdicionaAcao(new Multiplicador(3));
            builder.AdicionaAcao(new Multiplicador(5.5));

            NotaFiscal notaFiscal = builder.ParaEmpresa("Caelum")
                                .ComCnpj("123.456.789/0001-10")
                                .Com(new ItemDaNota("item 1", 100.0))
                                .Com(new ItemDaNota("item 2", 200.0))
                                .Com(new ItemDaNota("item 3", 300.0))
                                .ComObservacoes("entregar notaFiscal pessoalmente")
                                .NaData(DateTime.Now)
                                .Constroi();

            Console.ReadKey();
        }
    }
}

/**
 * Quando usar o Observer?
 * 
 * Quando o acoplamento da nossa classe está crescendo, ou quando temos diversas ações diferentes a serem executadas após um determinado processo, podemos implementar o Observer.
 * Ele permite que diversas ações sejam executadas de forma transparente à classe principal, reduzindo o acoplamento entre essas ações, facilitando a manutenção e evolução do código.
 */
