using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace _03_XX_MongoDB
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/account/login")
            });
        }
    }
}