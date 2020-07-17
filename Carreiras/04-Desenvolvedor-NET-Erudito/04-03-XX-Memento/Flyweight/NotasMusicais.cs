using System.Collections.Generic;

namespace _04_03_XX_Memento.Flyweight
{
    public class NotasMusicais
    {
        private static IDictionary<string, INota> notas = new Dictionary<string, INota>()
        {
            { "do", new Do() },
            { "re", new Re() },
            { "mi", new Mi() },
            { "fa", new Fa() },
            { "sol", new Sol() },
            { "la", new La() },
            { "si", new Si() }
        };

        public INota Pega(string nome)
        {
            return notas[nome];
        }
    }
}
