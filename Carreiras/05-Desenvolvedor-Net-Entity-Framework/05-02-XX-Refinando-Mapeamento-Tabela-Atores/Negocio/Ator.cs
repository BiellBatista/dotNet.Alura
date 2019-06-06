using System.ComponentModel.DataAnnotations.Schema;

namespace Alura.Filmes.App.Negocio
{
    [Table("Actor")]
    class Ator
    {
        [Column("actor_id")]
        public int Id { get; set; }
        [Column("first_name", TypeName = "varchar(45)")]
        public string PrimeiroNome { get; set; }
        //falando que esta coluna é do tipo varchar(45)
        [Column("last_name", TypeName = "varchar(45)")]
        public string UltimoNome { get; set; }

        public override string ToString()
        {
            return $"Ator ({Id}): {PrimeiroNome} {UltimoNome}";
        }
    }
}
