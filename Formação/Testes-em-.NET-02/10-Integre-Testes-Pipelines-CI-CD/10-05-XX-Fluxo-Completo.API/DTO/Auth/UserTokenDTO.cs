namespace _10_05_XX_Fluxo_Completo.API.DTO.Auth
{
    public class UserTokenDTO
    {
        public DateTime Expiration { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}