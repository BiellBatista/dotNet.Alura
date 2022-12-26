namespace _01_XX_Integracao_Entrega_Continua_Azure_DevOps.Domain.Entidades
{
    public class UsuarioApp
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}