using System.ComponentModel.DataAnnotations;

namespace _03_XX_Usuario.API.Data.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}