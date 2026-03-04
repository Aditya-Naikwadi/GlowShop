using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GlowShop.Startup))]
namespace GlowShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
