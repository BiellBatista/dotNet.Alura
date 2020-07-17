using _04_05_XX_Visitor.Visitor;

namespace _04_05_XX_Visitor.Interpreter
{
    public interface IExpressao
    {
        int Avalia();
        void Aceita(IVisitor impressora);
    }
}
