namespace _10_04_XX_Criando_Pipeline_Azure_Devops.API.DTO.Auth
{
    public class UserTokenDTO
    {
        public DateTime Expiration { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}