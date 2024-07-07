namespace _09_04_XX_Consultas.API.DTO.Auth
{
    public class UserTokenDTO
    {
        public DateTime Expiration { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}