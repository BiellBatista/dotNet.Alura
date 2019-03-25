using Microsoft.AspNet.Identity.EntityFramework;

namespace ASP_NET_Identity_Parte_4.Models
{
    public class UserAplication : IdentityUser
    {
        public string FullName { get; set; }
    }
}