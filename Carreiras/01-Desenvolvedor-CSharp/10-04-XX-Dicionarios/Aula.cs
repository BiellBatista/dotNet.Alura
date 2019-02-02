using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_04_XX_Dicionarios
{
    class Aula : IComparable
    {
        public string Titulo { get; set; }
        public int Tempo { get; set; }

        public Aula(string titulo, int tempo)
        {
            Titulo = titulo;
            Tempo = tempo;
        }

        public override string ToString()
        {
            return $"O título da aula é {Titulo} e possui a duração de {Tempo}";
        }

        public int CompareTo(object obj)
        {
            var tmp = obj as Aula;

            return this.Titulo.CompareTo(tmp.Titulo);
        }
    }
}
