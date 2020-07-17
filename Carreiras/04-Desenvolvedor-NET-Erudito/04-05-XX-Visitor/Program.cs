using _04_05_XX_Visitor.Interpreter;
using _04_05_XX_Visitor.Visitor;

namespace _04_05_XX_Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            IExpressao esquerda = new Subtracao(new Numero(10), new Numero(5));
            IExpressao direita = new Soma(new Numero(2), new Numero(10));

            IExpressao conta = new Soma(esquerda, direita);

            Impressora impressora = new Impressora();
            conta.Aceita(impressora);
        }
    }
}
