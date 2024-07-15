namespace _10_03_XX_Publicando_Pipeline.API.DTO.Auth
{
    public class UserTokenDTO
    {
        public DateTime Expiration { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}