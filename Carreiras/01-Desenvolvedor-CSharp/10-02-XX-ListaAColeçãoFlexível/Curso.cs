using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_02_XX_ListaAColeçãoFlexível
{
    class Curso
    {
        private List<Aula> _aulas;

        public IList<Aula> Aulas { get { return new ReadOnlyCollection<Aula>(_aulas); } }


        public string Nome { get; set; }
        public string Instrutor { get; set; }

        public int TempoTotal {
            get
            {
                //int total = 0;

                //foreach (var aula in _aulas)
                //    total += aula.Tempo;
                //return total;

                //LINQ = Language Integrated Query 
                //Consultas Integrada à Linguagem
                return _aulas.Sum(aulas => aulas.Tempo);
            }
        }

        public Curso(string nome, string instrutor)
        {
            Nome = nome;
            Instrutor = instrutor;

            _aulas = new List<Aula>();
        }
        internal void Adiciona(Aula aula)
        {
            _aulas.Add(aula);
        }

        public override string ToString()
        {
            return $"Curso: {Nome}, Tempo: {TempoTotal}, Aulas: {string.Join(",", _aulas)}";
        }
    }
}
