namespace _01_XX_Integracao_Entrega_Continua_Azure_DevOps.WebApp.Views.ViewModel
{
    public class UsuarioAppViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}