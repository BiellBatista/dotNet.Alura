using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_03_XX_ConsultandoLINQ
{
    class Mes : IComparable
    {
        public string Nome { get; private set; }
        public int Dias { get; private set; }

        public Mes(string nome, int dias)
        {
            Nome = nome;
            Dias = dias;
        }

        public override string ToString()
        {
            return $"{Nome} - {Dias}";
        }

        public int CompareTo(object obj)
        {
            Mes outro = obj as Mes;

            return Nome.CompareTo(outro.Nome);
        }
    }
}
