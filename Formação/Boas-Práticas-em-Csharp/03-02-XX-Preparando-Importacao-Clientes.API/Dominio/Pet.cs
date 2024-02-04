using System.ComponentModel.DataAnnotations;

namespace _03_02_XX_Preparando_Importacao_Clientes.API.Dominio
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