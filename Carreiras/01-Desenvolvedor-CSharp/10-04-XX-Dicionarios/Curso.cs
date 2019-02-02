using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_04_XX_Dicionarios
{
    class Curso
    {
        //alunos deve ser um ISet. Alunos deve retornar ReadOnlyCollection
        private ISet<Aluno> _alunos = new HashSet<Aluno>();
        private List<Aula> _aulas;
        private Dictionary<int, Aluno> _dicionarioAlunos = new Dictionary<int, Aluno>();

        public string Nome { get; set; }
        public string Instrutor { get; set; }

        public IList<Aluno> Alunos { get { return new ReadOnlyCollection<Aluno>(_alunos.ToList()); } }

        public IList<Aula> Aulas { get { return new ReadOnlyCollection<Aula>(_aulas); } }

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

        internal void SubstituiAluno(Aluno aluno)
        {
            _dicionarioAlunos.[aluno.NumeroMatricula] = aluno;
        }

        internal Aluno BuscaMatricula(int numeroMatricula)
        {
            Aluno aluno = null;
            //tentando pegar o valor e retornando o (out aluno) o aluno
            _dicionarioAlunos.TryGetValue(numeroMatricula, out aluno);
            return aluno;
            //pegando o valor com a chave [] tal..
            //return _dicionarioAlunos[numeroMatricula];
            //busca com ISet<>
            //foreach (var aluno in _alunos)
            //{
            //    if (aluno.NumeroMatricula == numeroMatricula)
            //        return aluno;
            //}

            //throw new Exception("Matricula não encontrada: " + numeroMatricula);
        }

        internal void Matricula(Aluno aluno)
        {
            _alunos.Add(aluno);
            _dicionarioAlunos.Add(aluno.NumeroMatricula, aluno);
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

        public bool EstaMatriculado(Aluno aluno)
        {
            return _alunos.Contains(aluno);
        }

        public override string ToString()
        {
            return $"Curso: {Nome}, Tempo: {TempoTotal}, Aulas: {string.Join(",", _aulas)}";
        }
    }
}
