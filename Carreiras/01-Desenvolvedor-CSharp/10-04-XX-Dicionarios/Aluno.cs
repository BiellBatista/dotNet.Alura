using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_04_XX_Dicionarios
{
    class Aluno
    {
        private string _nome;
        private int _numeroMatricula;

        public Aluno(string nome, int numeroMatricula)
        {
            _nome = nome;
            _numeroMatricula = numeroMatricula;
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public int NumeroMatricula
        {
            get { return _numeroMatricula; }
            set { _numeroMatricula = value; }
        }

        public override string ToString()
        {
            return $"Nome: {_nome}, Matrícula: {_numeroMatricula}";
        }

        public override bool Equals(object obj)
        {
            Aluno outro = obj as Aluno;

            if (outro == null)
                return false;
            else
                return Nome.Equals(outro.Nome);
        }

        //importante: rapidez da busca depende do código de dispersão!
        public override int GetHashCode()
        {
            //estou usando o nome, porque ele é usado no equals
            return Nome.GetHashCode();
        }

        //IMPORTANTE! SEMPRE QUE EU SOBRESCREVER O EQUALS, DEVO SOBRESCREVER O HASHCODE

        //Dois objetos que são iguais, possuem o mesmo hash code.
        //PORÉM, o contrário não é verdadeiro:
        //Dois objetos com mesmo hash codes não são necessaramente iguais!
    }
}
