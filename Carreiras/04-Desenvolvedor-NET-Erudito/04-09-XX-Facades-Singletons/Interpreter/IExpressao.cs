using _04_09_XX_Facades_Singletons.Visitor;

namespace _04_09_XX_Facades_Singletons.Interpreter
{
    public interface IExpressao
    {
        int Avalia();
        void Aceita(IVisitor impressora);
    }
}
