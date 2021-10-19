using System.ComponentModel.DataAnnotations;

namespace _05_XX_Usuario.API.Data.Requests
{
    public class AtivaContaRequest
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public string CodigoDeAtivacao { get; set; }
    }
}