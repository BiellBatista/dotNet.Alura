using System.Collections.Generic;

namespace _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Leiloes = new List<Leilao>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public IList<Leilao> Leiloes { get; set; }
    }

    public class CategoriaComInfoLeilao : Categoria
    {
        public int EmRascunho { get; set; }
        public int EmPregao { get; set; }
        public int Finalizados { get; set; }
    }
}