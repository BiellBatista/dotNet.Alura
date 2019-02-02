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
    }
}
