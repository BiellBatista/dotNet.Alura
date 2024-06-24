namespace _09_02_XX_Compartilhando_Contexto.API.DTO.Auth
{
    public class UserTokenDTO
    {
        public DateTime Expiration { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}