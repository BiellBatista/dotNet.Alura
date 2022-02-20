using System.ComponentModel.DataAnnotations;

namespace _02_XX_Usuario.API.Data.Requests
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}