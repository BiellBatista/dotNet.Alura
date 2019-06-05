using System.ComponentModel.DataAnnotations.Schema;

namespace Alura.Filmes.App.Negocio
{
    [Table("Actor")] //falando que quero usar a tabela Actor. Com isso, posso usar outro nome  de propriedade no contexto e quebro a regra de nome de tabela
    class Ator
    {
        public int Id { get; set; }
        [Column("")]
        public string PrimeiroNome { get; set; } //Geralmente, a propriedade possui o mesmo nome que a coluna
        public string UltimoNome { get; set; }
    }
}
