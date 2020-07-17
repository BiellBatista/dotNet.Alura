using System;

namespace _04_05_XX_Visitor.Interpreter
{
    public class RaizQuadrada : IExpressao
    {
        private IExpressao expressao;

        public RaizQuadrada(IExpressao e)
        {
            this.expressao = e;
        }

        public int Avalia()
        {
            return (int)Math.Sqrt(expressao.Avalia());
        }
    }
}
