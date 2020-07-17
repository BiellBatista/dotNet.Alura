using _04_08_XX_Adapter.Visitor;

namespace _04_08_XX_Adapter.Interpreter
{
    public interface IExpressao
    {
        int Avalia();
        void Aceita(IVisitor impressora);
    }
}
