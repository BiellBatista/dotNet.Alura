using _04_06_XX_Bridges.Visitor;

namespace _04_06_XX_Bridges.Interpreter
{
    public interface IExpressao
    {
        int Avalia();
        void Aceita(IVisitor impressora);
    }
}
