using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShop.PL.Startup))]
namespace WebShop.PL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
