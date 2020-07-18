using _04_09_XX_Facades_Singletons.Interpreter;

namespace _04_09_XX_Facades_Singletons.Visitor
{
    public interface IVisitor
    {
        void ImprimeSoma(Soma soma);
        void ImprimeSubtracao(Subtracao subtracao);
        void ImprimeNumero(Numero numero);
    }
}
