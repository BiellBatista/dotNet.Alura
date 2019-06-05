using System.ComponentModel.DataAnnotations.Schema;

namespace Alura.Filmes.App.Negocio
{
    [Table("Actor")] //falando que quero usar a tabela Actor. Com isso, posso usar outro nome  de propriedade no contexto e quebro a regra de nome de tabela
    class Ator
    {
        [Column("actor_id")]
        public int Id { get; set; }
        [Column("first_name")] //quebrando a regra de nome de coluna. Com isso, falo qual a coluna que esta propriedade referencia
        public string PrimeiroNome { get; set; } //Geralmente, a propriedade possui o mesmo nome que a coluna
        [Column("last_name")]
        public string UltimoNome { get; set; }

        public override string ToString()
        {
            return $"Ator ({Id}): {PrimeiroNome} {UltimoNome}";
        }
    }
}
