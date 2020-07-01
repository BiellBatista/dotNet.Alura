using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_03_XX_MongoDB.Startup))]
namespace _03_XX_MongoDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
