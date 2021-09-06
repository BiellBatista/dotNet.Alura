using System;
using System.Collections.Generic;

namespace _06_04_XX_Arrays.Depois
{
    public class Listas : IAulaItem
    {
        //Cronologia Star Wars
        //=========================================
        //Episódio I: A Ameaça Fantasma         1999
        //Episódio II: Ataque dos Clones        2002
        //A Guerra dos Clones                   2003
        //Episódio III: A Vingança dos Sith     2005
        //Rebels                                2014
        //Rogue One                             2016
        //Episódio IV -Uma nova esperança       1977
        //Episódio V -O Império Contra-Ataca    1980
        //Episódio VI -O Retorno de Jedi        1983
        //Episódio VII -O Despertar da Força    2015
        //Episódio VIII: Os Últimos Jedi        2017
        public void Executar()
        {
            //TAREFA PRINCIPAL
            //=================
            //colocar os filmes abaixo na ordem cronológica
            var esperanca = new Filme6("Episódio IV -Uma nova esperança", 1977);
            var imperio = new Filme6("Episódio V -O Império Contra-Ataca", 1980);
            var retorno = new Filme6("Episódio VI -O Retorno de Jedi", 1983);
            var ameaca = new Filme6("Episódio I: A Ameaça Fantasma", 1999);
            var ataque = new Filme6("Episódio II: Ataque dos Clones", 2002);
            var guerraClones = new Filme6("A Guerra dos Clones", 2003);
            var vinganca = new Filme6("Episódio III: A Vingança dos Sith", 2005);
            var rebels = new Filme6("Rebels", 2014);
            var despertar = new Filme6("Episódio VII -O Despertar da Força", 2015);
            var rogue = new Filme6("Rogue One", 2016);
            var ultimo = new Filme6("Episódio VIII: Os Últimos Jedi", 2017);

            //TAREFA: criar uma coleção vazia, que irá crescer aos poucos
            List<Filme6> cronologia = new List<Filme6>();

            //TAREFA: checar a capacidade da lista
            Console.WriteLine("tamanho da lista: " + cronologia.Count);
            Console.WriteLine("capacidade da lista: " + cronologia.Capacity);

            //TAREFA: adicionar o filme "Episódio IV -Uma nova esperança"
            cronologia.Add(esperanca);

            //TAREFA: checar novamente a capacidade da lista
            Console.WriteLine("tamanho da lista: " + cronologia.Count);
            Console.WriteLine("capacidade da lista: " + cronologia.Capacity);

            //TAREFA: Adicionar no final: Império Contra Ataca e Retorno de Jedi
            //cronologia.Add(imperio);
            //cronologia.Add(retorno);
            cronologia.AddRange(new List<Filme6> { imperio, retorno });

            //TAREFA: Declarar a lista com inicialização simplificada
            cronologia = new List<Filme6> { esperanca, imperio, retorno };

            //TAREFA: imprimir a cronologia
            Imprimir(cronologia);

            //TAREFA: inserir Ameaça Fantasma no início da cronologia
            int posicao = 1;
            cronologia.Insert(posicao - 1, ameaca);
            Imprimir(cronologia);

            //TAREFA: Inserir na segunda posição: Ataque dos Clones, Guerra dos Clone, Vingança dos Sith
            posicao = 2;
            var novosFilmes = new[] { ataque, guerraClones, vinganca, rebels };
            cronologia.InsertRange(posicao - 1, novosFilmes);
            Imprimir(cronologia);

            //TAREFA: adicionar Despertar da Força no fim da cronologia
            cronologia.Add(despertar);
            Imprimir(cronologia);

            //TAREFA: checar novamente a capacidade da lista
            Console.WriteLine("tamanho da lista: " + cronologia.Count);
            Console.WriteLine("capacidade da lista: " + cronologia.Capacity);

            //TAREFA: inserir Rogue One antes de Uma Nova Esperança
            //cronologia[5] = rogue;
            var indiceEsperanca = cronologia.IndexOf(esperanca);
            cronologia.Insert(indiceEsperanca, rogue);
            Imprimir(cronologia);

            //TAREFA: adicionar O Último Jedi ao final da cronologia
            cronologia.Add(ultimo);
            Imprimir(cronologia);

            //TAREFA: exibir a cronologia inversa
            cronologia.Reverse();
            Imprimir(cronologia);

            //TAREFA: voltar a cronologia à ordem original
            cronologia.Reverse();
            Imprimir(cronologia);

            //TAREFA: obter lista de filmes só com atores (sem rebels e guerra dos clones)
            var filmesComAtores = new List<Filme6>(cronologia);
            posicao = 5;
            filmesComAtores.RemoveAt(posicao - 1);
            Imprimir(filmesComAtores);
            filmesComAtores.Remove(guerraClones);
            Imprimir(filmesComAtores);

            //TAREFA: obter trilogia original (filmes lançados até 1983)
            var trilogiaOriginal = new List<Filme6>(cronologia);
            trilogiaOriginal.RemoveAll((filme) => filme.Ano > 1983);
            Imprimir(trilogiaOriginal);

            //TAREFA: exibir filmes em ordem alfabética
            var ordemAlfabetica = new List<Filme6>(filmesComAtores);
            ordemAlfabetica.Sort();
            Imprimir(ordemAlfabetica);

            //TAREFA: exibir filmes em ordem de lançamento
            var ordemLancamento = new List<Filme6>(filmesComAtores);
            ordemLancamento.Sort((filme1, filme2) => filme1.Ano.CompareTo(filme2.Ano));
            Imprimir(ordemLancamento);

            //TAREFA: exibir filmes da trilogia inicial (posições 4, 5 e 6)
            var trilogiaInicial = new Filme6[3];
            ordemLancamento.CopyTo(3, trilogiaInicial, 0, 3);
            Imprimir(trilogiaInicial);
        }

        private static void Imprimir(IEnumerable<Filme6> lista)
        {
            //for (int i = 0; i < cronologia.Count; i++)
            //{
            //    Filme filme = cronologia[i];
            //    Console.WriteLine(filme);
            //}

            foreach (var filme in lista)
            {
                Console.WriteLine(filme);
            }

            Console.WriteLine();
        }
    }

    public class Filme6 : IComparable
    {
        public Filme6(string titulo, int ano)
        {
            Titulo = titulo;
            Ano = ano;
        }

        public string Titulo { get; set; }
        public int Ano { get; set; }

        public int CompareTo(object obj)
        {
            Filme6 esta = this;
            Filme6 outra = obj as Filme6;

            if (outra == null)
            {
                return 1;
            }

            return esta.Titulo.CompareTo(outra.Titulo);
        }

        public override string ToString()
        {
            return $"{Titulo} - {Ano}";
        }
    }
}