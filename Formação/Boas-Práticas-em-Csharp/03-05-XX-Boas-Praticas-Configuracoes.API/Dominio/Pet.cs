using System.ComponentModel.DataAnnotations;

namespace _03_05_XX_Boas_Praticas_Configuracoes.API.Dominio
{
    public class Pet
    {
        public Pet()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string? Nome { get; set; }
        public TipoPet Tipo { get; set; }
    }
}