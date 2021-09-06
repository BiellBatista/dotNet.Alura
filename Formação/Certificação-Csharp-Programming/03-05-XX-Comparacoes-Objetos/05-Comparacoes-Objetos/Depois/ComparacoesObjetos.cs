﻿using System;
using System.Collections.Generic;

namespace _03_05_XX_Comparacoes_Objetos.Depois
{
    internal class ComparacoesObjetos : IAulaItem
    {
        public void Executar()
        {
            Aluno aluno1 = new Aluno
            {
                Nome = "José da Silva",
                DataNascimento = new DateTime(1990, 1, 1)
            };

            Aluno aluno2 = new Aluno
            {
                Nome = "José da Silva",
                DataNascimento = new DateTime(1995, 1, 1)
            };

            Aluno aluno3 = new Aluno
            {
                Nome = "josé da silva",
                DataNascimento = new DateTime(1990, 1, 1)
            };

            Console.WriteLine(aluno1.Equals(aluno2));
            Console.WriteLine(aluno1.Equals(aluno3));

            Aluno aluno4 = new Aluno
            {
                Nome = "ANDRÉ DOS SANTOS",
                DataNascimento = new DateTime(1970, 1, 1)
            };

            Aluno aluno5 = new Aluno
            {
                Nome = "Ana de Souza",
                DataNascimento = new DateTime(1990, 1, 1)
            };

            List<Aluno> alunos = new List<Aluno>
            {
                aluno1,
                aluno2,
                aluno3,
                aluno4,
                aluno5
            };

            alunos.Sort();

            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }
        }
    }

    internal class Aluno : IComparable
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, Data nascimento: {DataNascimento:dd/MM/yyyy}";
        }

        public override bool Equals(object obj)
        {
            Aluno outro = obj as Aluno;

            return Nome.Equals(outro?.Nome, StringComparison.CurrentCultureIgnoreCase) && DataNascimento.Equals(outro.DataNascimento);
        }

        public override int GetHashCode()
        {
            int hashCode = -1523756618;

            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + DataNascimento.GetHashCode();

            return hashCode;
        }

        public int CompareTo(object obj)
        {
            //retorna 0 => objetos são iguais
            //retorna > 0 => objeto atual vem depois
            //retorna < 0 => objeto atual vem antes

            Aluno outro = obj as Aluno;

            int resultado = DataNascimento.CompareTo(outro.DataNascimento);

            if (resultado == 0)
            {
                resultado = Nome.CompareTo(outro.Nome);
            }

            return resultado;
        }
    }
}