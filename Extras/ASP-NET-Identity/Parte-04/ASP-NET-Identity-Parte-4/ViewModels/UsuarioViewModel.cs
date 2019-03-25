using ASP_NET_Identity_Parte_4.Models;

namespace ASP_NET_Identity_Parte_4.ViewModels
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public UsuarioViewModel()
        {
        }

        public UsuarioViewModel(UserAplication usuario)
        {
            Id = usuario.Id;
            FullName = usuario.FullName;
            Email = usuario.Email;
            UserName = usuario.UserName;
        }
    }
}