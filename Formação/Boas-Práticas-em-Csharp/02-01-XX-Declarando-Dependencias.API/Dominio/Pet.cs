using System.ComponentModel.DataAnnotations;

namespace _02_01_XX_Declarando_Dependencias.API.Dominio
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
        public Cliente? Proprietario { get; set; }
    }
}