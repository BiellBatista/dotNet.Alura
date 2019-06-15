using Alura.Filmes.App.Extensions;
using System.Collections.Generic;

namespace Alura.Filmes.App.Negocio
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string AnoLancamento { get; set; }
        public short Duracao { get; set; }
        public string TextoClassificacao { get; private set; }
        // irei usar para manipular o valores que serão inseridos no banco
        public ClassificacaoIndicativa Classificacao
        {
            get
            {
                return TextoClassificacao.ParaValor();
            }
            set
            {
                TextoClassificacao = value.ParaString();
            }
        }
        public IList<FilmeAtor> Atores { get; set; }
        public Idioma IdiomaFalado { get; set; }
        public Idioma IdiomaOriginal { get; set; }
        public IEnumerable<FilmeCategoria> Categorias { get; internal set; }

        public Filme()
        {
            Atores = new List<FilmeAtor>();
        }

        public override string ToString()
        {
            return $"Filme ({Id}): {Titulo} - {Descricao} - {AnoLancamento}";
        }
    }
}

/**
 * O EF não consegue descobrir o relacionamento para duas propriedades da mesma classe
 */
