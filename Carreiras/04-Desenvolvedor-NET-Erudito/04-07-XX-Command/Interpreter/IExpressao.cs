using _04_07_XX_Command.Visitor;

namespace _04_07_XX_Command.Interpreter
{
    public interface IExpressao
    {
        int Avalia();
        void Aceita(IVisitor impressora);
    }
}
